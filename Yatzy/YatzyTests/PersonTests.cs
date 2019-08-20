using System.Collections.Generic;
using System.Linq;
using Xunit;
using YatzyLibrary;
using YatzyLibrary.Interfaces;

namespace YatzyTests
{
    public class PersonTests
    {
        class TestDie : IDie
        {
            public int Value { get; private set; }

            public TestDie(int valueToReturn)
            {
                Value = valueToReturn;
            }
            
            public void Roll()
            {
            }

            public void SetValue(int value)
            {
                Value = value;
            }
        }

        class TestDice : IDice
        {
            private int _defaultDieValue = 1;

            public List<TestDie> dice = new List<TestDie>();

            public TestDice()
            {
                for(var i = 0; i< 5; i++)
                    dice.Add(new TestDie(1));
            }
            
            public List<IDie> GetDice()
            {
                return new List<IDie>(dice);
            }

            public void Roll()
            {
            }

            public void RollSome(int[] toChange)
            {
            }

            public void SetRollResult(int dieNumber, int value)
            {
                dice[dieNumber].SetValue(value);
            }
        }

        [Fact]
        public void Check_dice_roll_works_in_person()
        {
            // Arrange
            var testDice = new TestDice();
            var person = new Player("Abby", testDice);
            
            // Act
            person.Roll(new[]{5,4,3,2,1});
            
            // Assert
            var expected = new[] {1, 1, 1, 1, 1};
            Assert.Equal(expected, person.GetDieList().Select(d => d.Value));
        }
        
        [Fact]
        public void Check_dice_a_second_roll_works_in_person()
        {
            // Arrange
            var testDice = new TestDice();
            var person = new Player("Abby", testDice);
            
            // Act
            person.Roll(new[]{5,4,3,2,1});
            
            // Assert
            var expected = new[] {1, 1, 1, 1, 1};
            Assert.Equal(expected, person.GetDieList().Select(d => d.Value));
            
            // Act
            testDice.SetRollResult(2,5);
            person.Roll(new[]{3});
            
            // Assert
            expected = new[] {1, 1, 5, 1, 1};
            Assert.Equal(expected, person.GetDieList().Select(d => d.Value));

        }
    }
}