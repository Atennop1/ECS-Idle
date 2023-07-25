using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Learning.Miners
{
    public sealed class MinersDisplaySystem : IEcsRunSystem
    {
        private readonly List<IMinerView> _minersViews;

        public MinersDisplaySystem(List<IMinerView> minersViews) 
            => _minersViews = minersViews ?? throw new ArgumentNullException(nameof(minersViews));

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var pool = world.GetPool<Miner>();
            var filter = world.Filter<Miner>().End();

            var counter = 0;
            foreach (var entity in filter)
            {
                _minersViews[counter].Display(pool.Get(entity));
                counter++;
            }

            if (_minersViews.Count <= counter) 
                return;

            for (var i = 0; i < _minersViews.Count - counter; i++) 
                _minersViews[_minersViews.Count - i - 1].Disable();
        }
    }
}