using System.Collections.Generic;
using System.Linq;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class YatzyGame
    {
        private Player _player;
        private readonly IResponseThingy _io;

        public YatzyGame(IResponseThingy io)
        {
            _io = io; 
            _player = new Player(io.GetPlayerName()); 
        }

        public void Play()
        {
            _io.PrintWelcome();
        }





        public void Round()
        {
            
        }
        
        public void Roll(int[] toRoll)
        {
            _player.Roll(toRoll);
        }

        public string[] GetDice()
        {
            var dice = new string[]{}; 
            List<Die> dies = _player.GetDieList();

            foreach (var die in dies)
            {
                dice.Append(die.Value.ToString());
            } 
            
            return dice;
        }
    }
}