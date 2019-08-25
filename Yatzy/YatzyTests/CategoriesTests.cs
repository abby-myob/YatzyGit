using System.Collections.Generic;
using Moq;
using Xunit;
using YatzyLibrary;
using YatzyLibrary.Interfaces;

namespace YatzyTests
{
    public class CategoriesTests
    {
        [Theory]
        [InlineData("three of a kind")] 
        public void check_category_is_used(string input)
        {
            // Arrange
            var categories = new Categories(new Dictionary<string, bool>
            {
                {input, false},
                {"yatzy", true},
                {"ones", false}, 
            });

            // Act 
            var used = categories.IsUsed(input);
            
            // Assert
            Assert.False(used);
        }
        
        [Theory]
        [InlineData("three of a kind")] 
        public void check_category_change_state(string input)
        {
            // Arrange
            var categories = new Categories(new Dictionary<string, bool>());

            // Act 
            categories.ChangeToUsed(input);
            
            // Assert
            Assert.True(categories.CategoryList[input]);
        }

        [Fact]
        public void check_categories_are_all_used()
        {
            // Arrange
            var categories = new Categories(new Dictionary<string, bool>
            {
                {"chance", true},
                {"yatzy", true},
                {"ones", true}, 
            });

            // Act 
            var allUsed = categories.AreAllUsed();
            
            // Assert
            Assert.True(allUsed);
        }
        
        [Fact]
        public void check_categories_are_not_all_used_with_one_unsed_category()
        {
            // Arrange
            var categories = new Categories(new Dictionary<string, bool>
            {
                {"chance", true},
                {"yatzy", true},
                {"ones", false}, 
            });

            // Act 
            var allUsed = categories.AreAllUsed();
            
            // Assert
            Assert.False(allUsed);
        }
        
        [Fact]
        public void check_category_status()
        {
            // Arrange
            var categories = new Categories(new Dictionary<string, bool>
            {
                {"chance", true},
                {"yatzy", true},
                {"ones", false}, 
            });

            // Act  
            
            // Assert
            Assert.True(categories.IsUsed("chance"));
            Assert.True(categories.IsUsed("yatzy"));
            Assert.False(categories.IsUsed("ones"));
        }

        
    }
}