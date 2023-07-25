using System;

namespace Learning.Miners
{
    [Serializable]
    public struct Miner
    {
        public string Name;
        public int Level;
        
        public int MiningPerTimeAmount;
        public float TimeBetweenMining;
        public float PassedMiningTime;
    }
}