using Xunit;

namespace YatzyTests
{
    public class RollTests
    {
        [Fact]
        public void check_dice_setting_method()
        {
            //Arrange
            Roll roll = new Roll();

            //Act
            roll.Roll();

            //Assert

        }
    }

    public class Roll
    {
    }
}