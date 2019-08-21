using System;

namespace YatzyLibrary
{
    public class Die : IDie
    {
        public int Value { get; private set; }

        public void SetDie(int value)
        {
            if (value > 6 || value < 1) throw new ArgumentException("Setting die value outside of 6 and 1");
            Value = value;
        }
    }
}