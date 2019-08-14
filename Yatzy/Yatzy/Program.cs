using System;
using System.Collections.Generic;
using YatzyLibrary;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yatzeeeeee");
            Console.WriteLine("Let's play");
            Console.WriteLine("What's your name?");
            
            List<string> names = new List<string>();
            names.Add(Console.ReadLine());
            YatzyGame yatzy = new YatzyGame(names);
        }
    }
}