using System.Collections.Generic;

namespace YatzyLibrary
{
    public interface IDice
    {
        List<Die> GetDice();
        void Roll();
    }
}