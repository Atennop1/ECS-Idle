using Learning.Score;
using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.EntryPoint
{
    public sealed class Game : MonoBehaviour
    {
        [SerializeField] private IScoreFactory _scoreFactory;
        
        private IEcsSystems _ecsSystems;
        private IEcsSystems _fixedEcsSystems;
        
        private void Awake()
        {
            var world = new EcsWorld();
            _ecsSystems = new EcsSystems(world);
            _fixedEcsSystems = new EcsSystems(world);

            _scoreFactory.Create(_ecsSystems);
            
            _ecsSystems.Init();
            _fixedEcsSystems.Init();
        }

        private void Update()
            => _ecsSystems.Run();

        private void FixedUpdate()
            => _fixedEcsSystems.Run();
    }
}
