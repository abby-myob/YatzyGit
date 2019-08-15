using System;
using System.Linq;

namespace YatzyLibrary
{
    public class CategoryLogic
    {
        public int Chance(int[] dice)
        {
            return dice.Sum();
        }

        public int Yatzy(int[] dice)
        {
            return (dice.All(d => d == dice[0])) ? 50 : 0;
        }

        public int SumNumber(int[] dice, int num)
        {
            return (dice.Where(d => d == num).Sum());
        }

        public int TwoPair(int[] dice)
        {
            int sum = 0, count = 0;

            Array.Sort(dice);
            Array.Reverse(dice);

            for (var i = 0; i < dice.Length - 1; i++)
            {
                if (dice[i] == dice[i + 1])
                {
                    sum += dice[i] * 2;
                    count++;
                    i++;
                }

                if (count == 2) return sum;
            }

            return 0;
        }

        public int NumberOfAKind(int[] dice, int numOfAKind)
        {
            for (var i = 6; i > 0; i--)
            {
                if (dice.Count(d => d == i) >= numOfAKind)
                {
                    return i * numOfAKind;
                }
            }

            return 0;
        }

        public int Straight(int[] dice)
        {
            Array.Sort(dice);

            for (int i = 0; i < dice.Length - 1; i++)
            {
                if (dice[i + 1] - dice[i] != 1) return 0;
            }

            return dice.Sum();
        }

        public int FullHouse(int[] dice)
        {
            bool threeOfAKindFound = false, twoOfAKindFound = false;
            var sum = 0;
            
            for (var i = 6; i > 0; i--)
            {
                if (dice.Count(d => d == i) >= 3 && threeOfAKindFound == false)
                {
                    sum += i * 3;
                    threeOfAKindFound = true;
                }
                else if (dice.Count(d => d == i) >= 2 && twoOfAKindFound == false)
                {
                    sum += i * 2;
                    twoOfAKindFound = true;
                }

                if (threeOfAKindFound && twoOfAKindFound) return sum;
            }

            return 0;
        }
    }
}