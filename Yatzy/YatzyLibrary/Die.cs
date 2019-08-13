namespace YatzyLibrary
{
    public class Die
    {
        public int Value { get; private set; }
        
        public Die()
        {
            Value = 1;
        }

        public void Roll()
        {
            Value = 5;
        }
    }
}