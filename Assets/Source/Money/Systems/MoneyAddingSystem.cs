using System;
using Leopotam.EcsLite;
using UnityEngine.UI;

namespace Learning.Money
{
    public sealed class MoneyAddingSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly Button _addingButton;

        public MoneyAddingSystem(Button addingButton) 
            => _addingButton = addingButton ?? throw new ArgumentNullException(nameof(addingButton));

        public void Init(IEcsSystems systems)
        {
            _addingButton.onClick.AddListener(() =>
            {
                var world = systems.GetWorld();
                var pool = world.GetPool<Money>();
                var filter = world.Filter<Money>().End();

                foreach (var entity in filter)
                    pool.Get(entity).Value++;
            });
        }

        public void Destroy(IEcsSystems systems) 
            => _addingButton.onClick.RemoveAllListeners();
    }
}