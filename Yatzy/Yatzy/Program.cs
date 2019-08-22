using System.Collections.Generic;
using YatzyLibrary;

namespace Yatzy
{
    internal static class Program
    {
        private static void Main(string[] args)
        { 
            var io = new ConsoleResponseThingy();

            var round = new Round(
                new Player(
                    new Categories(
                        new Dictionary<string, bool>()), io.GetPlayerName(), 0),
                new Roll(
                    new Hand(
                        new DieFactory())),
                new Scoring(
                    new CategoryLogic()),
                io);

            var game = new Game(round);
            
            game.Play();

        }
    }
}