using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class RollTests
    {
        [Fact]
        public void check_dice_initialRoll_method()
        {
            //Arrange
            var hand = new Hand();
            var roll = new Roll(hand);

            //Act
            roll.InitialRoll();
            int[] diceValues = roll.GetHand();

            //Assert
            foreach (var value in diceValues)
            {
                Assert.Equal(1, value);
            }
        }

        [Theory]
        [InlineData(new[] {2, 3, 4, 5, 6})]
        public void check_dice_rollAll_method(int [] expected)
        {
            //Arrange
            var fakeHand = new FakeHand(expected);
            var roll = new Roll(fakeHand);
            roll.InitialRoll();
            roll.RollAll();

            //Act  
            var diceValues = roll.GetHand();

            //Assert
            Assert.Equal(expected, diceValues);
        }
        
        [Theory]
        [InlineData(new[] {2, 3, 4, 5, 6}, new[] {2, 3, 4, 5})]
        public void check_dice_rollSome_method(int [] initial, int[] expected)
        {
            //Arrange
            var fakeHand = new FakeHand(initial);
            var roll = new Roll(fakeHand);
            roll.InitialRoll();
            roll.RollSome(new[] {false,false,false,false,true});

            //Act  
            var diceValues = roll.GetHand().Take(4);

            //Assert
            Assert.Equal(expected, diceValues);
        }
    }

    public class FakeHand : IHand
    {
        private readonly List<IDie> _dices = new List<IDie> { new Die(), new Die(), new Die(), new Die(), new Die() };
        private readonly int[] _values;

        public FakeHand(int[] values)
        {
            _values = values;
        }
        
        public int[] GetDices()
        {
            return _dices.Select(die => die.Value).ToArray();
        }

        public void SetDices(int[] values)
        {
            var i = 0;
            foreach (var die in _dices)
            {
                if (values[i] > 0) die.SetDie(_values[i]);
                i++;
            }
        }
    }
    
    
    
    
}