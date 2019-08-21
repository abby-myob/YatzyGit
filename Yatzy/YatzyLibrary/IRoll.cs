namespace YatzyLibrary
{
    public interface IRoll
    {
        IHand Hand { get; set; }
        void InitialRoll();
        void RollAll();
        int[] GetHand();
    }
}