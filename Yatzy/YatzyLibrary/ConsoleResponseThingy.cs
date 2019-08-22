using System;
using System.Collections.Generic;
using System.Linq;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class ConsoleResponseThingy : IResponseThingy 
    {

        public string GetPlayerName()
        {
            Console.WriteLine(Constants.GetPlayerName);
            return Console.ReadLine();
        }

        public Boolean RollAgainQuestion()
        {
            Console.WriteLine(Constants.RollAgainQuestion);
            return Console.ReadLine() == "y" || Console.ReadLine() == "Y";
        }

        public bool[] WhatDiceToRollAgain()
        {
            Console.WriteLine(Constants.WhatDiceToRollAgain);
            
            var output = new List<bool>();
            var input = Console.ReadLine(); 
            
            if (input == null) return output.ToArray();

            foreach (var die in input)
            { 
                output.Add(die == 'y');
            }
 
            return output.ToArray();
        }

        public string ChooseCategory()
        {
            Console.WriteLine(Constants.ChooseCategory);
            return Console.ReadLine();
        }
        
        public void PrintWelcome()
        {
            Console.WriteLine(Constants.Welcome);
        }
        
        public void PrintDice(int[] dice)
        {
            Console.Write(Constants.Dice);
            foreach (var die in dice)
            {
                Console.Write($"{die} ");
            } 
            Console.WriteLine("");
        }

        public void PrintScore(Player player)
        {
            Console.WriteLine($"{player.GetName()}{player.GetScore()}");
        }

        public void RollsToGo(int rolls)
        {
            Console.WriteLine(rolls == 0 ? Constants.NoRollsLeft : Constants.OneRollLeft);
        }
    }
}