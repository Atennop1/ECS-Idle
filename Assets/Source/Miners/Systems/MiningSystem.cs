using System;
using System.Collections.Generic;
using System.Linq;
using Learning.Tools;
using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class MiningSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly List<EcsPackedEntity> _packedMinerEntities;
        private readonly EcsPackedEntity _packedScoreEntity;

        private Score.Score _score;

        public MiningSystem(List<EcsPackedEntity> packedMinerEntities, EcsPackedEntity packedScoreEntity)
        {
            _packedMinerEntities = packedMinerEntities ?? throw new ArgumentNullException(nameof(packedMinerEntities));
            _packedScoreEntity = packedScoreEntity;
        }

        public Dictionary<EcsPackedEntity, Miner> MinersOfEntities;
        public Dictionary<EcsPackedEntity, float> PassedTimesOfEntities { get; private set; }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var minerEntities = _packedMinerEntities.Unpack(world);
            var minersPool = world.GetPool<Miner>();
            var miners = minerEntities.Select(entity => minersPool.Get(entity)).ToList();
            MinersOfEntities = _packedMinerEntities.ToDictionary(miners);

            _packedScoreEntity.Unpack(world, out var scoreEntity);
            _score = world.GetPool<Score.Score>().Get(scoreEntity);

            PassedTimesOfEntities = _packedMinerEntities.ToDictionary(new List<float>(_packedMinerEntities.Count));
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var pair in MinersOfEntities)
            {
                if (PassedTimesOfEntities[pair.Key] > pair.Value.TimeBetweenMining)
                {
                    PassedTimesOfEntities[pair.Key] += Time.deltaTime;
                    continue;
                }

                _score.Value += pair.Value.MiningPerTimeAmount;
                PassedTimesOfEntities[pair.Key] = 0;
            }
        }
    }
}