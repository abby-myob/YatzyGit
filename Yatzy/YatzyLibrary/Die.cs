using System;

namespace YatzyLibrary
{
    public interface IDie
    {
        int Value { get; }
        void SetDie(int value);
    }

    public class Die : IDie
    {
        public int Value { get; private set; }

        public Die(int value)
        {
            Value = value;
        }

        public void SetDie(int value)
        {
            if (value > 6 || value < 1) throw new ArgumentException("Setting die value outside of 6 and 1");
            Value = value;
        }
    }
}