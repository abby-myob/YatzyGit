using System.Collections.Generic;

namespace YatzyLibrary
{
    public interface IRoll
    {
        IHand Hand { get; set; }
        void InitialRoll();
        void RollAll();
        void RollSome(IEnumerable<bool> toRoll);
        int[] GetHand();
    }
}