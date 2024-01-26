using UnityEngine;
using UnityEngine.Serialization;

public abstract class PlayerStat : MonoBehaviour, IBoostable
{
    [SerializeField] private BoostType _appliableBoost;
    public abstract void IncrementBoostingValue(int amountToAdd);
    public abstract void DecrementBoostingValue(int amountToTake);
    public abstract int PreviewValueAfterApplying(int amountToApply);
    public abstract int PreviewValueAfterRemoving(int amountToApply);
    
    public BoostType AppliableBoost => _appliableBoost;
}
