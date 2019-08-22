using System.Collections.Generic;

namespace YatzyLibrary.Interfaces
{
    public interface ICategories
    {
        bool IsUsed(string input);
        void ChangeToUsed(string input);
        bool AreAllUsed();
        IDictionary<string, bool> ReturnCategories();
    }
}