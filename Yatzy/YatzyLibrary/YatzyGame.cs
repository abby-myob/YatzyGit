using System.Collections.Generic;
using System.Linq;
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
            _player = new Player(io.GetPlayerName()); 
        }

        public void Play()
        {
           _io.PrintDice(GetDice());

           if (_player.Categories.Count > 0)
           {
               Rolling();
               Scoring();

           }
        } 

        private void Rolling()
        {
            int rolls = 0; 
            while (rolls < 2)
            {
                _io.RollAgainQuestion();
                _player.Roll(_io.WhatDiceToRollAgain());
                _io.PrintDice(GetDice());
                _io.RollsToGo(rolls);
                rolls++;
            }
        }

        private void Scoring()
        {
            
        }


        public int[] GetDice()
        { 
            List<Die> dies = _player.GetDieList();

            IEnumerable<int> dice = dies.Select(x => x.Value); 

            return dice.ToArray();
        }
    }
}