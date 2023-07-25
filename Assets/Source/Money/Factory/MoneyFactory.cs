using Leopotam.EcsLite;
using SaveSystem;
using SaveSystem.Paths;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Money
{
    public sealed class MoneyFactory : SerializedMonoBehaviour, IMoneyFactory
    {
        [SerializeField] private IMoneyView _moneyView;
        [SerializeField] private Button _addingButton;
        
        public ref Money Create(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var entity = ecsWorld.NewEntity();
            
            var pool = ecsWorld.GetPool<Money>();
            pool.Add(entity);
            
            var saveStorage = new BinaryStorage<int>(new Path("Money.save"));
            if (saveStorage.HasSave())
                pool.Get(entity).Value = saveStorage.Load();
            
            systems.Add(new MoneyAddingSystem(_addingButton));
            systems.Add(new MoneyDisplaySystem(_moneyView));
            systems.Add(new MoneySavingSystem(saveStorage));

            return ref pool.Get(entity);
        }
    }
}