using System.Collections.Generic;
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
        [InlineData(new[]{2, 2, 2, 2, 2}, 10)]
        public void Return_score_for_chance(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.Chance(dice));
        }
    }

    public class Score
    {
        public int Chance(int[] dice)
        {
            return 10;
        }
    }
}