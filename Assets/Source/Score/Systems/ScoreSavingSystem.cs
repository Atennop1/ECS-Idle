using System;
using Leopotam.EcsLite;
using SaveSystem;

namespace Learning.Score
{
    public sealed class ScoreSavingSystem : IEcsDestroySystem
    {
        private readonly ISaveStorage<int> _saveStorage;

        public ScoreSavingSystem(ISaveStorage<int> saveStorage) 
            => _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));

        public void Destroy(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Score>();
            var filter = world.Filter<Score>().End();
            
            foreach (var entity in filter)
                _saveStorage.Save(pool.Get(entity).Value);
        }
    }
}