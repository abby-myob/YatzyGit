using System.Collections.Generic;
using YatzyLibrary.Interfaces;

namespace YatzyTests
{
    public class FakeCategories : ICategories
    { 
        public FakeCategories(Dictionary<string, bool> categoryList)
        {
            categoryList.Add("chance", true);
            categoryList.Add("yatzy", true);

            CategoryList = categoryList;
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
            return false;
        }

        public Dictionary<string, bool> CategoryList { get; set; }
        
    }
}