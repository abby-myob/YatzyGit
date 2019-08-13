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
        
        
    }
}