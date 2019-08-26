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

        public bool RollAgainQuestion()
        {
            Console.WriteLine(Constants.RollAgainQuestion);
            return Console.ReadLine() == "y";
        }

        public bool[] WhatDiceToRollAgain()
        {
            Console.WriteLine(Constants.WhatDiceToRollAgain);

            var output = new List<bool>();
            var input = Console.ReadLine();

            while (input != null && input.Length != 5)
            {
                Console.WriteLine(Constants.WhatDiceToRollAgain);
                input = Console.ReadLine();
            }

            if (input == null) input = "nnnnn";
            
            foreach (var die in input)
            {
                output.Add(die == 'y');
            }

            return output.ToArray();
        }

        public string ChooseCategory(IDictionary<string, bool> categories)
        {
            Console.WriteLine(Constants.ChooseCategory);
            var response = Console.ReadLine();
            while (categories.All(x => x.Key != response))
            {
                Console.WriteLine(Constants.ChooseCategory);
                response = Console.ReadLine();
            }

            return response;
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

        public void PrintScore(IPlayer player)
        {
            Console.WriteLine($"{player.GetName()}: {player.GetScore()}");
        }

        public void RollsToGo(int rolls)
        {
            Console.WriteLine(rolls == 0 ? Constants.NoRollsLeft : Constants.OneRollLeft);
        } 
        
        public void PrintCategories(IDictionary<string, bool> categories)
        {
            Console.Write(Constants.Categories);
            foreach (var (key, value) in categories)
            {
                if (value == false)
                {
                    Console.Write($"{key}, ");
                }
            }

            Console.WriteLine(" ");
        }
    }
}