using System.Collections.Generic;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Round : IRound
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

        public void Scoring()
        {
            var category = _io.ChooseCategory();
            if(_player.HasCategoryBeenUsed(category) == false)
            {
                _player.AddToScore(_scoring.CreateScore(category, _roll.GetHand()));
                _player.RemoveCategory(category);
            } 
            _io.PrintScore(_player);

            _io.PrintCategories(_player.ReturnCategories().CategoryList);
        }

        public bool AreCategoriesEmpty()
        {
            return _player.IsAllOutOfCategories();
        }

        public void PrintScores()
        {
            _io.PrintScore(_player);
        }
    }
}