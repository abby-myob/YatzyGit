using System;
using System.Collections.Generic;

namespace YatzyLibrary
{
    public class Dice : IDice
    {
        private readonly List<Die> _diceList;

        public Dice()
        {
            _diceList = new List<Die>
            {
                new Die(), new Die(), new Die(), new Die(), new Die()
            };
        } 
        
        public List<Die> GetDice()
        {
            return _diceList;
        }

        public void Roll()
        {
            foreach (var die in _diceList)
            {
                die.Roll();
            }
        }

        public void RollSome(int[] toChange)
        {
            for (int i = 0; i <= toChange.Length; i++)
            {
                _diceList[i].Roll();
            }
        }
    }
}