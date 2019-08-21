using System.Collections.Generic;

namespace YatzyLibrary
{
    public interface IHand
    {
        int[] GetDices();
        void SetDices(int[] values);
    }
}