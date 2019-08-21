using System.Collections.Generic;
using System.Linq;

namespace YatzyLibrary
{
    public class Hand : IHand
    {
        private readonly List<IDie> _dices = new List<IDie>
        {
            new Die(), new Die(), new Die(), new Die(), new Die()
        };

        public int[] GetDices()
        {
            return _dices.Select(die => die.Value).ToArray();
        }

        public void SetDices(int[] values)
        {
            var i = 0;
            foreach (var die in _dices)
            {
                if (values[i] > 0) die.SetDie(values[i]);
                i++;
            }
        }
    }
}