using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using SaveSystem;

namespace Learning.Miners
{
    public sealed class MinersSavingSystem : IEcsDestroySystem
    {
        private readonly ISaveStorage<List<Miner>> _saveStorage;

        public MinersSavingSystem(ISaveStorage<List<Miner>> saveStorage) 
            => _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
        
        public void Destroy(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Miner>();
            var filter = world.Filter<Miner>().End();

            var result = new List<Miner>(filter.GetEntitiesCount());
            foreach (var entity in filter)
                result.Add(pool.Get(entity));
            
            _saveStorage.Save(result);
        }
    }
}