using Xunit;
using Xunit.Sdk;
using YatzyLibrary;
using YatzyLibrary.Interfaces;

namespace YatzyTests
{
    class TestResponse : IResponseThingy
    {
        public bool RollAgainResponse;
        
        public string GetPlayerName()
        {
            throw new System.NotImplementedException();
        }

        public bool RollAgainQuestion()
        {
            return RollAgainResponse;
        }

        public int[] WhatDiceToRollAgain()
        {
            throw new System.NotImplementedException();
        }

        public string ChooseCategory()
        {
            throw new System.NotImplementedException();
        }

        public void PrintWelcome()
        {
            throw new System.NotImplementedException();
        }

        public void PrintDice(int[] dice)
        {
            throw new System.NotImplementedException();
        }

        public void PrintScore(Player player)
        {
            throw new System.NotImplementedException();
        }

        public void RollsToGo(int rolls)
        {
            throw new System.NotImplementedException();
        }
    }

    public class RoundTest
    {
        [Fact]
        public void ScoringShould()
        {
            var io = new TestResponse();
            
            
            var dice = new Dice();
            Player player = new Player("test", dice);
            var round = new Round(io, player);

            io.RollAgainResponse = false;
            round.Play();

            //int expectedScore;
            //Assert.Equal(expectedScore, player.Score);

        }


        
    }
}