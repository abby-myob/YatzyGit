using System.Collections.Generic;
using System.Linq;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Round
    {
        private IResponseThingy Io { get; }
        private Player Player { get; }

        public Round(IResponseThingy io, Player player)
        {
            Io = io;
            Player = player;
        }

        public void Play()
        {
            Rolling();
            Scoring();
        } 

        private void Rolling()
        {
            int rolls = 0; 
            while (rolls < 2)
            {
                var shouldRollAgain = Io.RollAgainQuestion(); // use the boolean from the answer

                if(shouldRollAgain)
                {
                    Roll(rolls);
                    rolls++;
                }
                else
                {
                    break;
                }
            }
        }

        private void Roll(int rolls)
        {
            Player.Roll(Io.WhatDiceToRollAgain()); // todo 
            Io.PrintDice(GetDice());
            Io.RollsToGo(rolls);
        }

        private void Scoring()
        {
            // Choose category
            
            // Get Score
            
            // remove category 
        }
        
        public int[] GetDice()
        { 
            List<IDie> dies = Player.GetDieList();

            IEnumerable<int> dice = dies.Select(x => x.Value); 

            return dice.ToArray();
        }
    }
}