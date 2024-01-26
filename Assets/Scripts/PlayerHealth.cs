using System;
using UnityEngine;

public class PlayerHealth : PlayerStat, IHealth
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public event Action OnPlayerDead;

    public void Heal(int amount)
    {
        if (_health + amount ! > _maxHealth)
        {
            _health += amount;
        }
    }
    public void ApplyDamage(int dealingDamage)
    {
        if (_health - dealingDamage > 0)
        {
            _health -= dealingDamage;
        }
        else
        {
            OnPlayerDead?.Invoke();
        }
    }

    public override void IncrementBoostingValue(int amountToAdd) => _maxHealth += amountToAdd;
    public override void DecrementBoostingValue(int dealingDamage)
    {
        if (_maxHealth - dealingDamage ! < 0) _maxHealth -= dealingDamage;
    }

    public override int PreviewValueAfterApplying(int amountToApply) => _maxHealth + amountToApply;
    public override int PreviewValueAfterRemoving(int amountToApply) => _maxHealth - amountToApply;
}
