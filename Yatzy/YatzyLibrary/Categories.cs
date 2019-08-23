using System.Collections.Generic;
using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Categories : ICategories
    { 
        public Dictionary<string, bool> CategoryList { get; set; }

        public Categories(Dictionary<string, bool> categoryList)
        {
            CategoryList = categoryList;
        }


        public bool IsUsed(string input)
        {
            return CategoryList[input];
        }

        public void ChangeToUsed(string input)
        {
            CategoryList[input] = true;
        }

        public bool AreAllUsed()
        {
            foreach (var category in CategoryList)
            {
                if (category.Value == false) return false;
            }

            return true; 
        }
   
    }
}