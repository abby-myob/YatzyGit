using System.Collections.Generic;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class HandTests
    {
        [Fact]
        public void check_dice_setting_method()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.SetDices(new[] {3, 3, 3, 3, 3});
            
            // Assert
            foreach (var die in hand.GetDices())
            {
                Assert.Equal(3, die.Value);
            }
        }
    }
} 

public interface IHand
{
    IEnumerable<IDie> GetDices();
    void SetDices(int[] values);
}

public class Hand : IHand
{
    private readonly List<IDie> _dices = new List<IDie>
    {
        new Die(1), new Die(1), new Die(1), new Die(1), new Die(1)
    };

    public IEnumerable<IDie> GetDices()
    {
        return _dices;
    }

    public void SetDices(int[] values)
    {
        var i = 0;
        foreach (var die in _dices)
        {
            die.SetDie(values[i]);
            i++;
        }
    }
} 