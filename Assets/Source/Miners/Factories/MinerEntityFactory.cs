using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class MinerEntityFactory : MonoBehaviour
    {
        public int Create(IEcsSystems systems, Miner miner)
        {
            var world = systems.GetWorld();
            var entity = world.NewEntity();
            
            var pool = world.GetPool<Miner>();
            pool.Add(entity);
            ref var createdMiner = ref pool.Get(entity);
            
            createdMiner.Name = miner.Name;
            createdMiner.Level = miner.Level;
            createdMiner.TimeBetweenMining = miner.TimeBetweenMining;
            createdMiner.MiningPerTimeAmount = miner.MiningPerTimeAmount;
            createdMiner.PassedMiningTime = miner.PassedMiningTime;

            return entity;
        }
    }
}