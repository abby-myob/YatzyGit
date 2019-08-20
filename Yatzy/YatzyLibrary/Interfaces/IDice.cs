using System.Collections.Generic;

namespace YatzyLibrary.Interfaces
{
    public interface IDice
    {
        List<IDie> GetDice();
        void Roll();
        void RollSome(int[] toChange);
    }
}