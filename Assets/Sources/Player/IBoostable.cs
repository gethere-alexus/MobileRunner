namespace Sources.Player
{
    public interface IBoostable
    {
        public void Increment(int amountToAdd);
        public void Decrement(int amountToTake);
        public int GetValueWithApplying(int amountToApply);
        public int GetValueWithRemoving(int amountToApply);
    }
}