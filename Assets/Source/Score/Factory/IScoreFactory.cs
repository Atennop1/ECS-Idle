using Leopotam.EcsLite;

namespace Learning.Score
{
    public interface IScoreFactory
    {
        ref Score Create(IEcsSystems systems);
    }
}