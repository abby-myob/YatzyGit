using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace YatzyTests
{
//    public class ScoringTests
//    {
//        [Fact]
//        public void Dice_Input_Return_Score_for_chance_category()
//        {
//            var dice = new List<Dice>();
//            SetUpDice(dice);
//
//            var scorer = new Scorer();
//
//            scorer.GetScore(dice, category); 
//        }
//
// 
//    }
    
    public class DiceTests
    {
        [Fact]
        public void Dice_Roll()
        {
            var dice = new Dice();

            dice.Roll();

            List<Die> list = dice.GetDie();

            foreach (var die in list)
            {
                Assert.Equal(1, die.Value);
            }
        }

 
    }

    public class Die
    {
        public Die()
        {
            Value = 1;
        }

        public int Value { get; set; }
    }

    public class Dice
    {
        public void Roll()
        {
            
        }

        public List<Die> GetDie()
        {
            List<Die> dice = new List<Die>();
            
            for (int i = 0; i < 5; i++)
            {
                dice.Add(new Die());
            }

            return dice;
        }
    }
}