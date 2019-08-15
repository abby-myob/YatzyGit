using System.Collections.Generic;

namespace YatzyLibrary.Interfaces
{
    public interface IDice
    {
        List<Die> GetDice();
        void Roll();
    }
}