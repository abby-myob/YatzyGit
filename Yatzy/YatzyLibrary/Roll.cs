using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyLibrary
{
    public class Roll : IRoll
    {
        public IHand Hand { get; set; }
        public Roll(IHand hand)
        {
            Hand = hand;
        }

        public void InitialRoll()
        {
            Hand.SetDices(new[]{1,1,1,1,1});
        }
        
        public void RollAll()
        {
            var random = new Random();
            Hand.SetDices(new[]
            { 
                random.Next(1,7), random.Next(1,7), random.Next(1,7), random.Next(1,7), random.Next(1,7), 
            });
        }

        public int[] GetHand()
        {
            return Hand.GetDices();
        }

        public void RollSome(bool[] toRoll)
        {
            var random = new Random();
            var values = toRoll.Select(isRoll => isRoll ? random.Next(1, 7) : 0).ToList();

            Hand.SetDices(values.ToArray());
        }
    }
}