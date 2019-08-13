using System.Collections.Generic; 

namespace YatzyLibrary
{
    public class Dice
    {  
        public List<Die> DiceList = new List<Die>();

        public List<Die> GetDice()
        {
            var dice = new List<Die>();
            
            for (var i = 0; i < 5; i++)
            {
                dice.Add(new Die());
            }

            return dice;
        }
    }
}