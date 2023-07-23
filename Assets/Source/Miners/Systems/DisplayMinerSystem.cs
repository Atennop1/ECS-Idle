using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Learning.Miners
{
    public sealed class DisplayMinerSystem : IEcsRunSystem
    {
        private readonly Dictionary<EcsPackedEntity, IMinerView> _viewsOfMinerEntities;

        public DisplayMinerSystem(Dictionary<EcsPackedEntity, IMinerView> viewsOfMinerEntities) 
            => _viewsOfMinerEntities = viewsOfMinerEntities ?? throw new ArgumentNullException(nameof(viewsOfMinerEntities));

        public void Run(IEcsSystems systems)
        {
            var miningSystem = systems.GetShared<MiningSystem>();
            
            foreach (var pair in _viewsOfMinerEntities)
                pair.Value.Display(miningSystem.MinersOfEntities[pair.Key], miningSystem.PassedTimesOfEntities[pair.Key]);
        }
    }
}