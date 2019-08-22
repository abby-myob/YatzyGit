using YatzyLibrary.Interfaces;

namespace YatzyLibrary
{
    public class Scoring : IScoring
    {
        private readonly ICategoryLogic _categoryLogic;

        public Scoring(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        public int CreateScore(string category, int[] hand)
        {
            switch (category)
            {  
                case "ones":
                    return _categoryLogic.SumNumber(hand, 1);
                case "twos":
                    return _categoryLogic.SumNumber(hand, 2);
                case "threes":
                    return _categoryLogic.SumNumber(hand, 3);
                case "fours":
                    return _categoryLogic.SumNumber(hand, 4);
                case "fives":
                    return _categoryLogic.SumNumber(hand, 5);
                case "sixes":
                    return _categoryLogic.SumNumber(hand, 6);

                case "chance":
                    return _categoryLogic.Chance(hand);
                case "yatzy":
                    return _categoryLogic.Yatzy(hand);
                
                case "pair":
                    return _categoryLogic.NumberOfAKind(hand, 2);
                case "two pair":
                    return _categoryLogic.TwoPair(hand);
                case "three of a kind":
                    return _categoryLogic.NumberOfAKind(hand, 3);
                case "four of a kind":
                    return _categoryLogic.NumberOfAKind(hand, 4);
                
                case "small straight":
                    return _categoryLogic.Straight(hand);
                case "large straight":
                    return _categoryLogic.Straight(hand);
                case "full house":
                    return _categoryLogic.FullHouse(hand);
            }

            return 0;
        } 
    }
}