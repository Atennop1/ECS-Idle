using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class MinerEntityFactory : MonoBehaviour
    {
        public int Create(IEcsSystems systems, MinerCreationData creationData)
        {
            var world = systems.GetWorld();
            var entity = world.NewEntity();
            
            var pool = world.GetPool<Miner>();
            pool.Add(entity);

            ref var createdMiner = ref pool.Get(entity);
            createdMiner.Name = creationData.Name;
            createdMiner.TimeBetweenMining = creationData.TimeBetweenMining;
            createdMiner.MiningPerTimeAmount = creationData.MiningPerTimeAmount;
            createdMiner.Level = 1;

            return entity;
        }
    }
}