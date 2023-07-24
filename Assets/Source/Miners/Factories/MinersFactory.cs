using System.Collections.Generic;
using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class MinersFactory : SerializedMonoBehaviour
    {
        [SerializeField] private MinerEntityFactory _minerEntityFactory;
        
        [Space]
        [SerializeField] private List<MinerCreationData> _minersCreationData;
        [SerializeField] private List<IMinerView> _minersViews;

        public List<Miner> Create(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Miner>();
            
            var creatingCount = System.Math.Min(_minersCreationData.Count, _minersViews.Count);
            var miners = new List<Miner>(creatingCount);

            for (var i = 0; i < creatingCount; i++)
            {
                var entity = _minerEntityFactory.Create(systems, _minersCreationData[i]);
                miners.Add(pool.Get(entity));
            }

            systems.Add(new MiningSystem());
            systems.Add(new MinersDisplaySystem(_minersViews));

            return miners;
        }
    }
}