using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Game : IGame
    {
        private readonly IRound _round;

        public Game(IRound round)
        {
            _round = round;
        }

        public void Play()
        {
            while (!GameIsOver())
            {
                _round.StartRolling();
                _round.Scoring();
            }

            _round.PrintScores();
        }

        private bool GameIsOver()
        {
            return _round.AreCategoriesEmpty();
        }
    }
}