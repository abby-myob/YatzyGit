using System;
using System.Collections.Generic;

namespace YatzyLibrary.Interfaces
{
    public interface IResponseThingy
    {
        string GetPlayerName();
        Boolean RollAgainQuestion();
        bool[] WhatDiceToRollAgain();
        string ChooseCategory(IDictionary<string, bool> categories); 
        void PrintDice(int[] dice);
        void PrintScore(IPlayer player);
        void RollsToGo(int rolls);
        void PrintCategories(IDictionary<string, bool> categories);
    }
}