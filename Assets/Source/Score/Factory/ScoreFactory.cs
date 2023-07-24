using Leopotam.EcsLite;
using SaveSystem;
using SaveSystem.Paths;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Score
{
    public sealed class ScoreFactory : SerializedMonoBehaviour, IScoreFactory
    {
        [SerializeField] private IScoreView _scoreView;
        [SerializeField] private Button _addingButton;
        
        public ref Score Create(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var entity = ecsWorld.NewEntity();
            
            var pool = ecsWorld.GetPool<Score>();
            pool.Add(entity);
            
            var saveStorage = new BinaryStorage<int>(new Path("Score.json"));
            if (saveStorage.HasSave())
                pool.Get(entity).Value = saveStorage.Load();
            
            systems.Add(new ScoreAddingSystem(_addingButton));
            systems.Add(new ScoreDisplaySystem(_scoreView));
            systems.Add(new ScoreSavingSystem(saveStorage));

            return ref pool.Get(entity);
        }
    }
}