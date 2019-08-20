using YatzyLibrary;

namespace Yatzy
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var consoleIo = new ConsoleResponseThingy();
            var yatzy = new YatzyGame(consoleIo);
            
            yatzy.Play(); 
        }
    }

}