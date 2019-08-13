using System;

namespace YatzyLibrary
{
    public class Die : IDie
    {
        public int Value { get; private set; }
        private readonly Random _random = new Random();
        
        public Die()
        {
            Value = _random.Next(1, 7);
        } 
        public void Roll()
        { 
            Value = _random.Next(1, 7);
        }
    }
}