using System.Collections.Generic;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class PersonTests
    {
        [Fact]
        public void Check_dice_roll_works_in_person()
        {
            var person = new Person("Abby");

            person.Roll(new[]{5,4,3});
            List<Die> list = person.GetDieList();
            
            foreach (var die in list)
            {
                Assert.True(die.Value > 0 && die.Value < 7);
            }
        }
    }
}