using Sources.StaticData;

namespace Sources.Player
{
    [System.Serializable]
    public class Statistic : IBoostable
    {
        public StatisticDescription StatDescription;
        public int DefaultValue;
        private int _currentValue;

        public Statistic(StatisticDescription statDescription, int defaultValue)
        {
            StatDescription = statDescription;
            DefaultValue = defaultValue;
            _currentValue = DefaultValue;
        }

        public virtual void Increment(int amountToAdd) => _currentValue += amountToAdd;

        public virtual void Decrement(int amountToTake)
        {
            if (_currentValue - amountToTake > 0)
            {
                _currentValue -= amountToTake;
            }
        }

        public virtual int GetValueWithApplying(int amountToApply) =>
            DefaultValue + amountToApply;

        public virtual int GetValueWithRemoving(int amountToApply) =>
            DefaultValue - amountToApply;
    }
}