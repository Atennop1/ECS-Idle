using System;
using JetBrains.Annotations;
using Leopotam.EcsLite;

namespace Learning.Score
{
    public sealed class ScoreDisplaySystem : IEcsRunSystem
    {
        [NotNull] private readonly IScoreView _scoreView;

        public ScoreDisplaySystem([NotNull] IScoreView scoreView) 
            => _scoreView = scoreView ?? throw new ArgumentNullException(nameof(scoreView));

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var scoresPool = world.GetPool<Score>();
            var scoreFilter = world.Filter<Score>().End();

            foreach (var entity in scoreFilter)
            {
                ref var score = ref scoresPool.Get(entity);
                _scoreView.Display(score.Value);
            }
        }
    }
}