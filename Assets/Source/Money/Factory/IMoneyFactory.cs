using Leopotam.EcsLite;

namespace Learning.Money
{
    public interface IMoneyFactory
    {
        ref Money Create(IEcsSystems systems);
    }
}