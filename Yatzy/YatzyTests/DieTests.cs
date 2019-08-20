using System;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class DieTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        [InlineData(4)]
        [InlineData(1)] 
        public void Return_set_die(int expected)
        {
            //Arrange
            IDie die = new Die(1);
            //Act
            die.SetDie(expected);
            //Assert
            Assert.Equal(expected, die.Value);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(7)]
        [InlineData(87)]
        public void exception_with_incorrect_die_setting(int input)
        {
            //arrange
            var die = new Die(1); 
            //act
            void Act() => die.SetDie(input);
            //assert
            Assert.Throws<ArgumentException>(Act);
        }
    }
}