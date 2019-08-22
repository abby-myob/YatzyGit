using System.Collections.Generic;
using System.Linq;

namespace YatzyLibrary
{
    public interface IDieFactory
    {
        IDie CreateDie();
    }

    public class DieFactory: IDieFactory
    {
        public IDie CreateDie()
        {
            return new Die();
        }
    }

    public class Hand : IHand
    {
        private readonly IDieFactory _dieFactory;

        public Hand(IDieFactory dieFactory)
        {
            _dieFactory = dieFactory;
            
            _dices = new List<IDie>
            {
                _dieFactory.CreateDie(), 
                _dieFactory.CreateDie(), 
                _dieFactory.CreateDie(), 
                _dieFactory.CreateDie(), 
                _dieFactory.CreateDie(), 
            };
        }

        private readonly List<IDie> _dices;

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