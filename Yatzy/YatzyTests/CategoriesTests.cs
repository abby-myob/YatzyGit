using System.Collections.Generic;
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
            var categories = new Categories(new Dictionary<string, bool>());

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
            Assert.True(categories.IsUsed(input));
        }

        [Fact]
        public void check_category_is_all_used()
        {
            // Arrange
            var categories = new FakeCategories(new Dictionary<string, bool>());

            // Act 
            var allUsed = categories.AreAllUsed();
            
            // Assert
            Assert.True(allUsed);
        }

        
    }

    public class FakeCategories : ICategories
    {
        private readonly Dictionary<string, bool> _categoryList;

        public FakeCategories(Dictionary<string, bool> categoryList)
        {
            categoryList.Add("chance", true);
            categoryList.Add("yatzy", true);

            _categoryList = categoryList;
        }
        public bool IsUsed(string input)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeToUsed(string input)
        {
            throw new System.NotImplementedException();
        }

        public bool AreAllUsed()
        {
            foreach (var category in _categoryList)
            {
                if (category.Value == false) return false;
            }

            return true;
        }
    }
}