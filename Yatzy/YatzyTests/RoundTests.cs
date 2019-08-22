
using System;
using System.Collections.Generic;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class RoundTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        [InlineData(4)]
        [InlineData(1)] 
        public void Return_set_die(int expected)
        {
            //Arrange
            Round round = new Round(
                new Player(
                    new Categories(
                        new Dictionary<string, bool>()), "ab", 0), 
                new Roll(
                    new Hand(
                        new DieFactory())),
                new Scoring(
                    new CategoryLogic()), 
                new ConsoleResponseThingy()
                );
            
            //Act
            //round.StartRound();
            
            //Assert
            //Assert.Equal(expected, die.Value);
        }
    }
}