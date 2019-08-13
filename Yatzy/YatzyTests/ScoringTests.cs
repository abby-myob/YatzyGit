using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class DiceTests
    {
        [Fact]
        public void Get_dice_list_check_value_to_be_1()
        {
            var dice = new Dice();

            List<Die> list = dice.GetDice();

            foreach (var die in list)
            {
                Assert.Equal(1, die.Value);
            }
        }

        [Fact]
        public void Check_dice_list_is_always_length_5()
        {
            var dice = new Dice();

            List<Die> list = dice.GetDice();

            Assert.Equal(5, list.Count);
        }
    }

    public class ScoringTests
    {
        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 10)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 14)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 21)]
        [InlineData(new[] {5, 1, 5, 7, 1}, 19)]
        public void Return_score_for_chance(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.Chance(dice));
        }


        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 50)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 0)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 0)]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 50)]
        public void Return_score_for_Same_Number(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.SameNumber(dice));
        }

        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 1, 0)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 1, 2)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 1, 1)]
        [InlineData(new[] {1, 1, 1, 1, 1}, 1, 5)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 1, 0)]
        [InlineData(new[] {2, 2, 2, 2, 2}, 2, 10)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 3, 6)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 5, 10)]
        [InlineData(new[] {1, 1, 1, 3, 1}, 1, 4)]
        [InlineData(new[] {5, 5, 5, 3, 5}, 1, 0)]
        public void Return_score_for_Ones(int[] dice, int num, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.SumNumber(dice, num));
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 8)]
        [InlineData(new[] {1, 1, 6, 2, 6}, 12)]
        [InlineData(new[] {3, 3, 3, 4, 1}, 6)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 6)]
        public void Return_score_for_Pair(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.NumberOfAKind(dice, 2));
        }

        [Theory]
        [InlineData(new[] {1, 1, 2, 3, 3}, 8)]
        [InlineData(new[] {1, 1, 2, 3, 4}, 0)]
        [InlineData(new[] {1, 1, 2, 2, 2}, 6)]
        public void Return_score_for_Two_Pair(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.TwoPair(dice));
        }
        
        [Theory]
        [InlineData(new[] {1, 1, 3, 3, 3}, 9)]
        [InlineData(new[] {1, 1, 2, 3, 4}, 0)]
        [InlineData(new[] {1, 1, 2, 2, 2}, 6)]
        [InlineData(new[] {1, 2, 2, 2, 2}, 6)]
        public void Return_score_for_3ofAKind(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.NumberOfAKind(dice,3));
        }
        
        [Theory]
        [InlineData(new[] {2,2,2,2,5}, 8)]
        [InlineData(new[] {6,6,6,6,6}, 24)]
        [InlineData(new[] {3,3,4,5,6}, 0)]
        [InlineData(new[] {3,3,3,3,1}, 12)]
        public void Return_score_for_4ofAKind(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.NumberOfAKind(dice,4));
        }
        
        [Theory]
        [InlineData(new[] {1,2,3,4,5}, 15)] 
        [InlineData(new[] {3,3,3,3,1}, 0)]
        [InlineData(new[] {5,6,2,4,3}, 20)]
        public void return_score_for_straight(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.Straight(dice));
        }
    }

    public class Score
    {
        public int Chance(int[] dice)
        {
            return dice.Sum();
        }

        public int SameNumber(int[] dice)
        {
            return (dice.All(d => d == dice[0])) ? 50 : 0;
        }

        public int SumNumber(int[] dice, int num)
        {
            return (dice.Where(d => d == num).Sum());
        }
        
        public int TwoPair(int[] dice)
        {
            int sum = 0, count = 0;

            Array.Sort(dice);
            Array.Reverse(dice);

            for (var i = 0; i < dice.Length - 1; i++)
            {
                if (dice[i] == dice[i + 1])
                {
                    sum += dice[i] * 2;
                    count++;
                    i++;
                }

                if (count == 2) return sum;
            }

            return 0;
        }

        public int NumberOfAKind(int[] dice, int numOfAKind)
        {  
            for (var i = 6; i > 0; i--)
            {
                if (dice.Count(d => d == i) >= numOfAKind)
                {
                    return i * numOfAKind;
                }
            } 
            return 0;
        }

        public int Straight(int[] dice)
        {
            Array.Sort(dice);

            for (int i = 0; i < dice.Length - 1; i++)
            {
                if (dice[i + 1] - dice[i] != 1) return 0;
            }

            return dice.Sum();
        }
    }
}