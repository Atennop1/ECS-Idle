using System;
using Leopotam.EcsLite;
using SaveSystem;

namespace Learning.Score
{
    public sealed class ScoreSavingSystem : IEcsDestroySystem
    {
        private readonly ISaveStorage<int> _saveStorage;
        private readonly EcsPackedEntity _ecsPackedEntity;

        public ScoreSavingSystem(ISaveStorage<int> saveStorage, ref EcsPackedEntity ecsPackedEntity)
        {
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
            _ecsPackedEntity = ecsPackedEntity;
        }

        public void Destroy(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Score>();

            _ecsPackedEntity.Unpack(world, out var entity);
            _saveStorage.Save(pool.Get(entity).Value);
        }
    }
}