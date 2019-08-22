using System.Globalization;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Player : IPlayer
    {
        private readonly ICategories _categories;
        private readonly string _name;
        private int _score;

        public Player(ICategories categories, string name, int score)
        {
            _categories = categories;
            
            TextInfo tInfo = new CultureInfo("en-US", false).TextInfo;
            _name = tInfo.ToTitleCase(name);
            _score = score;
        }

        public string GetName()
        {
            return _name;
        }

        public void AddToScore(int points)
        {
            _score += points;
        }

        public int GetScore()
        {
            return _score;
        }

        public void RemoveCategory(string category)
        {
            _categories.ChangeToUsed(category);
        }

        public bool HasCategoryBeenUsed(string category)
        {
            return _categories.IsUsed(category);
        }

        public bool IsAllOutOfCategories()
        {
            return _categories.AreAllUsed();
        }

        public ICategories ReturnCategories()
        {
            return _categories;
        }
    }
}