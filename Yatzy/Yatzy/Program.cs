using System.Collections.Generic;
using YatzyLibrary;

namespace Yatzy
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
//            var consoleIo = new ConsoleResponseThingy();
//            var yatzy = new YatzyGame(consoleIo);
//            
//            yatzy.Play(); 

            var round = new Round(
                new Player(
                    new Categories(
                        new Dictionary<string, bool>()), "abby", 0),
                new Roll(
                    new Hand(
                        new DieFactory())),
                new Scoring(
                    new CategoryLogic()),
                new ConsoleResponseThingy());

            round.StartRolling();
        }
    }
}