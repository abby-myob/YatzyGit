using System.Collections.Generic;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Categories : ICategories
    {
        private readonly IDictionary<string, bool> _categoryList;

        public Categories(IDictionary<string, bool> categoryList)
        {
            categoryList.Add("chance", false);
            categoryList.Add("yatzy", false);
            
            categoryList.Add("ones", false);
            categoryList.Add("twos", false);
            categoryList.Add("threes", false);
            categoryList.Add("fours", false);
            categoryList.Add("fives", false);
            categoryList.Add("sixes", false);
            
            categoryList.Add("pair", false);
            categoryList.Add("two pair", false);
            categoryList.Add("three of a kind", false);
            categoryList.Add("four of a kind", false);
            categoryList.Add("small straight", false);
            categoryList.Add("large straight", false);
            categoryList.Add("full house", false);

            _categoryList = categoryList;
        }


        public bool IsUsed(string input)
        {
            return _categoryList[input];
        }

        public void ChangeToUsed(string input)
        {
            _categoryList[input] = true;
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