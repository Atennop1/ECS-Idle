using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.EntryPoint
{
    public sealed class Game : MonoBehaviour
    {
        private IEcsSystems _ecsSystems;
        private IEcsSystems _fixedEcsSystems;
        
        private void Awake()
        {
            var world = new EcsWorld();
            _ecsSystems = new EcsSystems(world);
            _fixedEcsSystems = new EcsSystems(world);
            
            _ecsSystems.Init();
            _fixedEcsSystems.Init();
        }

        private void Update()
            => _ecsSystems.Run();

        private void FixedUpdate()
            => _fixedEcsSystems.Run();
    }
}
