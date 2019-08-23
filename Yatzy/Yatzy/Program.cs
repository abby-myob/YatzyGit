using System.Collections.Generic;
using YatzyLibrary;

namespace Yatzy
{
    internal static class Program
    {
        private static void Main(string[] args)
        { 
            var io = new ConsoleResponseThingy();
            var categoryList = new Dictionary<string, bool>
            {
                {"chance", false},
                {"yatzy", false},
                {"ones", false},
                {"twos", false},
                {"threes", false},
                {"fours", false},
                {"fives", false},
                {"sixes", false},
                {"pair", false},
                {"two pair", false},
                {"three of a kind", false},
                {"four of a kind", false},
                {"small straight", false},
                {"large straight", false},
                {"full house", false}
            };
 
            var round = new Round(
                new Player(
                    new Categories(
                        categoryList), io.GetPlayerName(), 0),
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