using System;
using System.Collections.Generic;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Dice : IDice
    {
        private readonly List<IDie> _diceList;

        public Dice()
        {
            _diceList = new List<IDie>
            {
                new Die(), new Die(), new Die(), new Die(), new Die()
            };
        } 
        
        public List<IDie> GetDice()
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
            foreach (var x in toChange)
            {
                _diceList[x - 1].Roll();
            }
        }
    }
}