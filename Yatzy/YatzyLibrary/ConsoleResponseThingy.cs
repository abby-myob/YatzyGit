using System;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class ConsoleResponseThingy : IResponseThingy
    {

        public string GetPlayerName()
        {
            Console.WriteLine("Please enter a player name:");
            return Console.ReadLine();
        }

        public Boolean RollAgainQuestion()
        {
            Console.WriteLine("Would you like to roll again? (y/n)");
            return Console.ReadLine() != "y" || Console.ReadLine() != "Y";
        }

        public int[] WhatDiceToRollAgain()
        {
            Console.WriteLine("What dice would you like to roll again? (1,4,5)");
            
            // get list of dice and then output as a int[]
            return new []{2, 3, 4};
        }

        public string ChooseCategory()
        {
            Console.WriteLine("Please choose your category");
            return Console.ReadLine();
        }
        
        public void PrintWelcome()
        {
            Console.WriteLine("Welcome to Yatzy");
        }
        
        public void PrintDice(int[] dice)
        {
            Console.Write("Dice: ");
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
    }
}