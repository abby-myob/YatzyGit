using System;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Die : IDie
    {
        public int Value { get; private set; }
        private readonly Random _random = new Random();
        
        public Die()
        {
            Roll();
        } 
        public void Roll()
        { 
            Value = _random.Next(1, 7);
        }
    }
}