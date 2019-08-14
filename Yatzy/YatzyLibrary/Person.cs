using System.Collections.Generic;

namespace YatzyLibrary
{
    public class Person
    {
        private string Name { get; }
        private readonly Dice _dice = new Dice();
        
        public Person(string name)
        {
            Name = name;
        }

        public void Roll(int[] toChange)
        {
            if(toChange.Length >= 5) _dice.Roll();
            _dice.RollSome(toChange); 
        }

        public List<Die> GetDieList()
        {
            return _dice.GetDice();
        }
    }
}