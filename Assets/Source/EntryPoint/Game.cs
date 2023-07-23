using Learning.Score;
using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Learning.EntryPoint
{
    public sealed class Game : SerializedMonoBehaviour
    {
        [SerializeField] private IScoreFactory _scoreFactory;

        private EcsWorld _ecsWorld;
        private IEcsSystems _ecsSystems;
        private IEcsSystems _fixedEcsSystems;
        
        private void Awake()
        {
            _ecsWorld = new EcsWorld();
            _ecsSystems = new EcsSystems(_ecsWorld);
            _fixedEcsSystems = new EcsSystems(_ecsWorld);

            _scoreFactory.Create(_ecsSystems);
            
            _ecsSystems.Init();
            _fixedEcsSystems.Init();
        }

        private void Update()
            => _ecsSystems.Run();

        private void FixedUpdate()
            => _fixedEcsSystems.Run();

        private void OnDestroy()
        {
            _ecsSystems.Destroy();
            _fixedEcsSystems.Destroy();
            _ecsWorld.Destroy();
        }
    }
}
