using System;
using Leopotam.EcsLite;
using UnityEngine.UI;

namespace Learning.Score
{
    public sealed class ScoreAddingSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly Button _addingButton;

        public ScoreAddingSystem(Button addingButton) 
            => _addingButton = addingButton ?? throw new ArgumentNullException(nameof(addingButton));

        public void Init(IEcsSystems systems)
        {
            _addingButton.onClick.AddListener(() =>
            {
                var world = systems.GetWorld();
                var pool = world.GetPool<Score>();
                var filter = world.Filter<Score>().End();

                foreach (var entity in filter)
                    pool.Get(entity).Value++;
            });
        }

        public void Destroy(IEcsSystems systems) 
            => _addingButton.onClick.RemoveAllListeners();
    }
}