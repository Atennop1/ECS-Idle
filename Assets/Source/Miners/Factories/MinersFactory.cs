using System.Collections.Generic;
using Leopotam.EcsLite;
using SaveSystem;
using SaveSystem.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class MinersFactory : SerializedMonoBehaviour
    {
        [SerializeField] private MinerEntityFactory _minerEntityFactory;
        
        [Space]
        [SerializeField] private MinerCreationData _basicMinerCreationData;
        
        [Space]
        [SerializeField] private List<IMinerView> _minersViews;

        public List<Miner> Create(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Miner>();

            var minersStorage = new BinaryStorage<List<Miner>>(new Path("Miners.save"));
            var miners = new List<Miner>();

            if (minersStorage.HasSave())
            {
                var loadedMiners = minersStorage.Load();
                var creatingCount = System.Math.Min(loadedMiners.Count, _minersViews.Count);

                for (var i = 0; i < creatingCount; i++)
                {
                    var entity = _minerEntityFactory.Create(systems, loadedMiners[i]);
                    miners.Add(pool.Get(entity));
                }
            }
            else
            {
                var entity = _minerEntityFactory.Create(systems, new Miner
                {
                    Level = 1,
                    Name = _basicMinerCreationData.Name,
                    MiningPerTimeAmount = _basicMinerCreationData.MiningPerTimeAmount,
                    TimeBetweenMining = _basicMinerCreationData.TimeBetweenMining
                });
                
                miners.Add(pool.Get(entity));
            }

            systems.Add(new MiningSystem());
            systems.Add(new MinersDisplaySystem(_minersViews));
            systems.Add(new MinersSavingSystem(minersStorage));

            return miners;
        }
    }
}