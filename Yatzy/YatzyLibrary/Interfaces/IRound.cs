namespace YatzyLibrary.Interfaces
{
    public interface IRound
    {
        void StartRolling();
        void Scoring();
        bool AreCategoriesEmpty();
        void PrintScores();
    }
}