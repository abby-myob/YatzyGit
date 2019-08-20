using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class YatzyGame
    {
        private readonly Player _player;
        private readonly IResponseThingy _io;

        public YatzyGame(IResponseThingy io)
        { 
            _io = io; 
            _io.PrintWelcome();
            var dice = new Dice();
            _player = new Player(io.GetPlayerName(), dice); 
        }

        public void Play()
        {
            Round round = new Round(_io, _player);

            if (_player.IsGameOver())
            {
                round.Play();
            }
        } 
    }
}