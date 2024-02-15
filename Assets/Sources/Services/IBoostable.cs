namespace Sources.Services
{
    public interface IBoostable
    {
        public void IncrementBoostingValue(int amountToAdd);
        public void DecrementBoostingValue(int amountToTake);
        public int PreviewValueAfterApplying(int amountToApply);
        public int PreviewValueAfterRemoving(int amountToApply);
    }
}