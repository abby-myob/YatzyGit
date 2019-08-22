namespace YatzyLibrary.Interfaces
{
    public interface IPlayer
    {
        string GetName();
        void AddToScore(int points);
        int GetScore();
        void RemoveCategory(string category);
        bool HasCategoryBeenUsed(string category);
        bool IsAllOutOfCategories();
        ICategories ReturnCategories();
    }
}