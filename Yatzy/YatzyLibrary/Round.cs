using System.Linq;
using System.Runtime.InteropServices;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Round
    {
        private readonly IPlayer _player;
        private readonly IRoll _roll;
        private readonly IScoring _scoring;
        private readonly IResponseThingy _io;

        public Round(IPlayer player, IRoll roll, IScoring scoring, IResponseThingy io)
        {
            _player = player;
            _roll = roll;
            _scoring = scoring;
            _io = io;
        }

        public void StartRolling()
        {
            _roll.RollAll();
            _io.PrintDice(_roll.GetHand());
            for (var i = 0; i < 2; i++)
            {
                if (_io.RollAgainQuestion() == false)
                {
                    _io.PrintDice(_roll.GetHand());
                    break;
                }
                _roll.RollSome(_io.WhatDiceToRollAgain());
                _io.PrintDice(_roll.GetHand());
            }
        }

        public void Category()
        {
            while (_player.HasCategoryBeenUsed(_io.ChooseCategory()) == false)
            {
                _scoring.CreateScore(_io.ChooseCategory(), _roll.GetHand());
                //_player.
            }
            
           
        }
    }
}