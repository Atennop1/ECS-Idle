using System;
using Leopotam.EcsLite;

namespace Learning.Score
{
    public sealed class ScoreDisplaySystem : IEcsRunSystem
    {
        private readonly IScoreView _scoreView;

        public ScoreDisplaySystem(IScoreView scoreView) 
            => _scoreView = scoreView ?? throw new ArgumentNullException(nameof(scoreView));

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<Score>();
            var filter = world.Filter<Score>().End();
            
            foreach (var entity in filter)
                _scoreView.Display(pool.Get(entity).Value);
        }
    }
}