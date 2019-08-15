using System.Collections.Generic;

namespace YatzyLibrary
{
    public class Player
    {
        public string Name { get; }
        private readonly Dice _dice;
        public int Score { get; private set; }
        public List<string> Categories { get; }

        public Player(string name)
        {
            Name = name;
            _dice = new Dice();
            Score = 0;
            Categories = new List<string>
            {
                "Chance", "Yatzy", "Ones", "Twos", "Threes", "Fours", "Fives", "Sixes", "Pair", "Two Pairs",
                "Three of a Kind", "Found of a Kind", "Small Straight", "Large Straight", "Full House"
            };
        }

        public void Roll(int[] toChange)
        {
            if (toChange.Length >= 5) _dice.Roll();
            _dice.RollSome(toChange);
        }

        public List<Die> GetDieList()
        {
            return _dice.GetDice();
        } 

        public void UpdateScore(int points)
        {
            Score = points;
        }

        public void RemoveCategories(string category)
        {
            Categories.Remove(category);
        } 
    }
}