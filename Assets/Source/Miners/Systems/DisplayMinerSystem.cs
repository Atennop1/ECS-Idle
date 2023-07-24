using System;
using System.Collections.Generic;
using Learning.Tools;
using Leopotam.EcsLite;

namespace Learning.Miners
{
    public sealed class DisplayMinerSystem : IEcsRunSystem
    {
        private readonly List<IMinerView> _minerViews;

        public DisplayMinerSystem(List<IMinerView> minerViews) 
            => _minerViews = minerViews ?? throw new ArgumentNullException(nameof(minerViews));

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var pool = world.GetPool<Miner>();
            var filter = world.Filter<Miner>().End();
            var miners = filter.GetEntities(pool);
            
            for (var i = 0; i < miners.Count; i++)
                _minerViews[i].Display(miners[i]);
        }
    }
}