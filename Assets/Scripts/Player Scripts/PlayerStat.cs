using UnityEngine;

public abstract class PlayerStat : MonoBehaviour, IBoostable
{
    [SerializeField] private BoostDataContainer _appliableBoost;
    [SerializeField] protected int _value, _maxValue;
    [SerializeField] protected int _defaultValue, _defaultMaxValue;

    private void Awake()
    {
        if(_value > _maxValue ) _value = _maxValue;
        
        _defaultValue = _value;
        _defaultMaxValue = _maxValue;
    }

    public virtual void IncrementBoostingValue(int amountToAdd) => _value += amountToAdd;

    public virtual void DecrementBoostingValue(int amountToTake)
    {
        if (_value - amountToTake > 0)
        {
            _value -= amountToTake;
        }
    }
    public virtual int PreviewValueAfterApplying(int amountToApply) => _value + amountToApply;
    public virtual int PreviewValueAfterRemoving(int amountToApply) => _value - amountToApply;
    
    public BoostDataContainer AppliableBoost => _appliableBoost;
    public virtual int BoostableValue => _value;
    public virtual int BoostImpact => _value - _defaultValue;
}
