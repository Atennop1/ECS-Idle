using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.Score
{
    public sealed class ScoreFactory : MonoBehaviour, IScoreFactory
    {
        [SerializeField] private IScoreView _scoreView;
        
        public ref Score Create(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var entity = ecsWorld.NewEntity();
            
            var pool = ecsWorld.GetPool<Score>();
            pool.Add(entity);
            systems.Add(new ScoreDisplaySystem(_scoreView));

            return ref pool.Get(entity);
        }
    }
}