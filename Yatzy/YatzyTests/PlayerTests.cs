using System.Collections.Generic;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class PlayerTests
    {
        [Theory]
        [InlineData("abby", "Abby")]
        [InlineData("Jim", "Jim")]
        [InlineData("sarah", "Sarah")]
        [InlineData("sarah west", "Sarah West")]
        public void check_player_name_getter(string input, string expected)
        {
            // Arrange
            var player = new Player(new Categories(new Dictionary<string, bool>()), input, 0);

            // Act 
            string name = player.GetName();

            // Assert
            Assert.Equal(expected, name);
        }
        
        [Theory]
        [InlineData(20, 20, 40)] 
        [InlineData(0, 32, 32)] 
        public void check_player_score(int input, int addition, int expected)
        {
            // Arrange
            var player = new Player(new Categories(new Dictionary<string, bool>()), "abby", input);

            // Act 
            player.AddToScore(addition);

            // Assert
            Assert.Equal(expected, player.GetScore());
        }
        
        [Theory]
        [InlineData("pair")] 
        public void remove_category(string category)
        {
            // Arrange
            var player = new Player(new Categories(new Dictionary<string, bool>()), "abb", 0);

            // Act 
            player.RemoveCategory(category);
            
            // Assert
            Assert.True(player.HasCategoryBeenUsed(category));
        }
        
        [Fact] 
        public void are_all_the_categories_dead()
        {
            // Arrange
            var player = new Player(new FakeCategories(new Dictionary<string, bool>()), "abb", 0);

            // Act 
            bool allout = player.IsAllOutOfCategories();
            
            // Assert
            Assert.True(allout);
        }

        
        
    }
}