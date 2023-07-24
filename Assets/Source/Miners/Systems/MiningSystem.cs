using Learning.Tools;
using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class MiningSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var scorePool = world.GetPool<Score.Score>();
            var scoreFilter = world.Filter<Score.Score>().End();
            var score = scoreFilter.GetEntities(scorePool)[0];
            
            var minersPool = world.GetPool<Miner>();
            var minersFilter = world.Filter<Miner>().End();
            var miners = minersFilter.GetEntities(minersPool);

            for (var i = 0; i < miners.Count; i++)
            {
                var valueMiner = miners[i];
                ref var miner = ref valueMiner;

                if (miner.PassedTime > miner.TimeBetweenMining)
                {
                    miner.PassedTime += Time.deltaTime;
                    continue;
                }

                score.Value += miner.MiningPerTimeAmount;
                miner.PassedTime = 0;
            }
        }
    }
}