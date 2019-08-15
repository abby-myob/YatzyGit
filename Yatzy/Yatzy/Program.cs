using System;
using System.Collections.Generic;
using YatzyLibrary;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleIO = new ConsoleResponseThingy();
            YatzyGame yatzy = new YatzyGame(consoleIO);
            
            yatzy.Play(); 
        }
    }

}