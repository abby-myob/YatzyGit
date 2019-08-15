using System;
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

        public int[] WhatDiceToRollAgain()
        {
            Console.WriteLine(Constants.WhatDiceToRollAgain);
            
            // get list of dice and then output as a int[]
            return new []{2, 3, 4};
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
            Console.WriteLine($"{player.Name}{player.Score}");
        }

        public void RollsToGo(int rolls)
        {
            Console.WriteLine(rolls == 1 ? Constants.NoRollsLeft : Constants.OneRollLeft);
        }
    }
}