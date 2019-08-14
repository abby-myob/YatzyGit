using System.Collections.Generic;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class YatzyTests
    {
        [Fact]
        public void Check_set_up_works()
        {
            YatzyGame yatzyGame = new YatzyGame(new List<string>{"abby"});
            
            Assert.True(yatzyGame._people.Count == 1);
        }
    }
}