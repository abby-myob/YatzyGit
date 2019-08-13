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
        
    }
}