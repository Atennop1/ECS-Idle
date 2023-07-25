using System;
using Leopotam.EcsLite;
using SaveSystem;

namespace Learning.Money
{
    public sealed class MoneySavingSystem : IEcsDestroySystem
    {
        private readonly ISaveStorage<int> _saveStorage;

        public MoneySavingSystem(ISaveStorage<int> saveStorage) 
            => _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));

        public void Destroy(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Money>();
            var filter = world.Filter<Money>().End();
            
            foreach (var entity in filter)
                _saveStorage.Save(pool.Get(entity).Value);
        }
    }
}