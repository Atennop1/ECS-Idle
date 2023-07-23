using System;
using Leopotam.EcsLite;

namespace Learning.Score
{
    public sealed class ScoreDisplaySystem : IEcsRunSystem
    {
        private readonly IScoreView _scoreView;
        private readonly EcsPackedEntity _ecsPackedEntity;

        public ScoreDisplaySystem(IScoreView scoreView, ref EcsPackedEntity ecsPackedEntity)
        {
            _scoreView = scoreView ?? throw new ArgumentNullException(nameof(scoreView));
            _ecsPackedEntity = ecsPackedEntity;
        }

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var scoresPool = world.GetPool<Score>();

            _ecsPackedEntity.Unpack(world, out var entity);
            _scoreView.Display(scoresPool.Get(entity).Value);
        }
    }
}