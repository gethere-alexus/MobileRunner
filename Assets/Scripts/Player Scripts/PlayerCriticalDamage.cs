using UnityEngine;

public class PlayerCriticalDamage : PlayerStat
{
    [SerializeField] private int _dealingCriticalDamage;

    public override void IncrementBoostingValue(int amountToAdd) => _dealingCriticalDamage += amountToAdd;
    public override void DecrementBoostingValue(int amountToTake)
    {
        if (_dealingCriticalDamage - amountToTake > 0)
        {
            _dealingCriticalDamage -= amountToTake;
        }
    }
    
    public override int PreviewValueAfterApplying(int amountToApply) => _dealingCriticalDamage + amountToApply;
    public override int PreviewValueAfterRemoving(int amountToApply) => _dealingCriticalDamage - amountToApply;
}
