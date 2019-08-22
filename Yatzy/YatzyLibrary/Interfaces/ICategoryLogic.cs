namespace YatzyLibrary.Interfaces
{
    public interface ICategoryLogic
    {
        int Chance(int[] dice);
        int Yatzy(int[] dice);
        int SumNumber(int[] dice, int num);
        int TwoPair(int[] dice);
        int NumberOfAKind(int[] dice, int numOfAKind);
        int Straight(int[] dice);
        int FullHouse(int[] dice);
    }
}