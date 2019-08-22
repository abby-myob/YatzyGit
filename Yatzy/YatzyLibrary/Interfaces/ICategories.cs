namespace YatzyLibrary.Interfaces
{
    public interface ICategories
    {
        bool IsUsed(string input);
        void ChangeToUsed(string input);
        bool AreAllUsed();
    }
}