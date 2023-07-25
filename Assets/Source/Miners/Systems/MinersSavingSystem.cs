using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using SaveSystem;

namespace Learning.Miners
{
    public sealed class MinersSavingSystem : IEcsDestroySystem
    {
        private readonly ISaveStorage<List<Miner>> _minersStorage;

        public MinersSavingSystem(ISaveStorage<List<Miner>> minersStorage) 
            => _minersStorage = minersStorage ?? throw new ArgumentNullException(nameof(minersStorage));
        
        public void Destroy(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Miner>();
            var filter = world.Filter<Miner>().End();

            var miners = new List<Miner>(filter.GetEntitiesCount());
            foreach (var entity in filter)
                miners.Add(pool.Get(entity));
            
            _minersStorage.Save(miners);
        }
    }
}