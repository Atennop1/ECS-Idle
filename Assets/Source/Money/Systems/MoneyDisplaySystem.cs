using System;
using Leopotam.EcsLite;

namespace Learning.Money
{
    public sealed class MoneyDisplaySystem : IEcsRunSystem
    {
        private readonly IMoneyView _moneyView;

        public MoneyDisplaySystem(IMoneyView moneyView) 
            => _moneyView = moneyView ?? throw new ArgumentNullException(nameof(moneyView));

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Money>();
            var filter = world.Filter<Money>().End();
            
            foreach (var entity in filter)
                _moneyView.Display(pool.Get(entity).Value);
        }
    }
}