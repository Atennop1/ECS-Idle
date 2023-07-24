using System.Collections.Generic;
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

            var minersPool = world.GetPool<Miner>();
            var minersFilter = world.Filter<Miner>().End();

            foreach (var minerEntity in minersFilter)
            {
                ref var miner = ref minersPool.Get(minerEntity);
                
                if (miner.PassedTime < miner.TimeBetweenMining)
                {
                    miner.PassedTime += Time.deltaTime;
                    continue;
                }
                
                foreach (var scoreEntity in scoreFilter) 
                    scorePool.Get(scoreEntity).Value += miner.MiningPerTimeAmount;
                
                miner.PassedTime = 0;
            }
        }
    }
}