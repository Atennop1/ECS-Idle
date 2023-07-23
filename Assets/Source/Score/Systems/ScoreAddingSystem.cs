using System;
using Leopotam.EcsLite;
using UnityEngine.UI;

namespace Learning.Score
{
    public sealed class ScoreAddingSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly Button _addingButton;
        private readonly EcsPackedEntity _ecsPackedEntity;

        public ScoreAddingSystem(Button addingButton, ref EcsPackedEntity ecsPackedEntity)
        {
            _addingButton = addingButton ?? throw new ArgumentNullException(nameof(addingButton));
            _ecsPackedEntity = ecsPackedEntity;
        }

        public void Init(IEcsSystems systems)
        {
            _addingButton.onClick.AddListener(() =>
            {
                var world = systems.GetWorld();
                _ecsPackedEntity.Unpack(world, out var entity);
                
                var pool = world.GetPool<Score>();
                pool.Get(entity).Value++;
            });
        }

        public void Destroy(IEcsSystems systems) 
            => _addingButton.onClick.RemoveAllListeners();
    }
}