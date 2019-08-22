using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyLibrary
{
    public class Roll : IRoll
    {
        public IHand Hand { get; set; }
        private readonly Random _random = new Random();
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
            Hand.SetDices(new[]
            { 
                _random.Next(1,7), _random.Next(1,7), _random.Next(1,7), _random.Next(1,7), _random.Next(1,7), 
            });
        }
        
        public void RollSome(IEnumerable<bool> toRoll)
        { 
            var values = toRoll.Select(isRoll => isRoll ? _random.Next(1, 7) : 0).ToList();

            Hand.SetDices(values.ToArray());
        }

        public int[] GetHand()
        {
            return Hand.GetDices();
        }
    }
}