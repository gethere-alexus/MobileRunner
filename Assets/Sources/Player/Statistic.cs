using ScriptableObjects;
using Sources.Services;

namespace Sources.Player
{
    [System.Serializable]
    public class Statistic : IBoostable
    {
        public StatisticDescription AplicableBoost;
        public int DefaultValue;
        
        
        public virtual void IncrementBoostingValue(int amountToAdd) => DefaultValue += amountToAdd;

        public virtual void DecrementBoostingValue(int amountToTake)
        {
            if (DefaultValue - amountToTake > 0)
            {
                DefaultValue -= amountToTake;
            }
        }

        public virtual int PreviewValueAfterApplying(int amountToApply) =>
            DefaultValue + amountToApply;

        public virtual int PreviewValueAfterRemoving(int amountToApply) =>
            DefaultValue - amountToApply;

        public virtual int BoostableValue =>
            DefaultValue;
    }
}