using System;

namespace Learning.Score
{
    public struct Score
    {
        private int _value;
        
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Score can't be negative number");

                _value = value;
            }
        }
    }
}