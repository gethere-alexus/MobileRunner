using Sources.StaticData;

namespace Sources.Player
{
    [System.Serializable]
    public class StatisticData : IBoostable
    {
        public StatisticType StatType;
        public int DefaultValue;

        public StatisticData(StatisticType statType, int defaultValue)
        {
            StatType = statType;
            DefaultValue = defaultValue;
        }

        public virtual void Increment(int amountToAdd) => 
            DefaultValue += amountToAdd;

        public virtual void Decrement(int amountToTake)
        {
            if (DefaultValue - amountToTake > 0)
            {
                DefaultValue -= amountToTake;
            }
        }

        public virtual int GetValueWithApplying(int amountToApply) =>
            DefaultValue + amountToApply;

        public virtual int GetValueWithRemoving(int amountToApply) =>
            DefaultValue - amountToApply;
    }
}