using System;
using System.Collections.Generic;
using Learning.Tools;
using Leopotam.EcsLite;

namespace Learning.Miners
{
    public sealed class DisplayMinersSystem : IEcsRunSystem
    {
        private readonly List<IMinerView> _minersViews;

        public DisplayMinersSystem(List<IMinerView> minersViews) 
            => _minersViews = minersViews ?? throw new ArgumentNullException(nameof(minersViews));

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var pool = world.GetPool<Miner>();
            var filter = world.Filter<Miner>().End();
            var miners = filter.GetEntities(pool);
            
            for (var i = 0; i < miners.Count; i++)
                _minersViews[i].Display(miners[i]);
        }
    }
}