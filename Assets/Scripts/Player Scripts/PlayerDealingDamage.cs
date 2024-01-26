using UnityEngine;

public class PlayerDealingDamage : PlayerStat
{
    [SerializeField] private int _dealingDamage;

    public override void IncrementBoostingValue(int amountToAdd) => _dealingDamage += amountToAdd;
    public override void DecrementBoostingValue(int amountToTake)
    {
        if (_dealingDamage - amountToTake > 0)
        {
            _dealingDamage -= amountToTake;
        }
    }
    
    public override int PreviewValueAfterApplying(int amountToApply) => _dealingDamage + amountToApply;
    public override int PreviewValueAfterRemoving(int amountToApply) => _dealingDamage - amountToApply;
}
