using System;
using Sources.Services;

namespace Sources.Player
{
    public class PlayerHealth : PlayerStat, IHealth
    {
        public event Action OnPlayerDead;

        public void Heal(int amount)
        {
            if (_value + amount ! > _maxValue)
            {
                _value += amount;
            }
        }
        public void ApplyDamage(int dealingDamage)
        {
            if (_value - dealingDamage > 0)
            {
                _value -= dealingDamage;
            }
            else
            {
                OnPlayerDead?.Invoke();
            }
        }

        public override void IncrementBoostingValue(int amountToAdd) => _maxValue += amountToAdd;
        public override void DecrementBoostingValue(int dealingDamage)
        {
            if (_maxValue - dealingDamage > 0) _maxValue -= dealingDamage;
        }
        public override int PreviewValueAfterApplying(int amountToApply) => _maxValue + amountToApply;
        public override int PreviewValueAfterRemoving(int amountToApply) => _maxValue - amountToApply;

        public override int BoostImpact => _maxValue - _defaultMaxValue;
        public override int BoostableValue => _maxValue;
        public override int DefaultBoostableValue => _defaultMaxValue;
    }
}
