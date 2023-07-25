using System;

namespace Learning.Money
{
    public struct Money
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