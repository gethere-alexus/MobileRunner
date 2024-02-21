using ScriptableObjects;

namespace Sources.Player
{
    [System.Serializable]
    public class Statistic : IBoostable
    {
        public StatisticDescription AplicableBoost;
        public int DefaultValue;
        private int _currentValue;

        public Statistic()
        {
            _currentValue = DefaultValue;
        }

        public virtual void IncrementBoostingValue(int amountToAdd) => _currentValue += amountToAdd;

        public virtual void DecrementBoostingValue(int amountToTake)
        {
            if (_currentValue - amountToTake > 0)
            {
                _currentValue -= amountToTake;
            }
        }

        public virtual int PreviewValueAfterApplying(int amountToApply) =>
            DefaultValue + amountToApply;

        public virtual int PreviewValueAfterRemoving(int amountToApply) =>
            DefaultValue - amountToApply;
    }
}