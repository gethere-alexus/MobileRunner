using UnityEngine;

public abstract class Appearance : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected int _price;
    [SerializeField] protected Boost[] _appearanceBoosts;
    
    protected bool _isPurchased;
    protected bool _isSelected;

  
    public void PurchaseAppearance()
    {
        _isPurchased = true;
    }

    public void SelectAppearance()
    {
        _isSelected = true;
        foreach (var boost in _appearanceBoosts)
        {
            GlobalEventBus.Sync.Publish(this, new OnBoostApplied(boost));
        }
    }

    public void UnselectAppearance()
    {
        _isSelected = false;
        foreach (var boost in _appearanceBoosts)
        {
            GlobalEventBus.Sync.Publish(this, new OnBoostRemoved(boost));
        }
    }

    public void ShowAppearanceOnScene()
    {
        this.gameObject.SetActive(true);
    }

    public void HideAppearance()
    {
        this.gameObject.SetActive(false);
    }

    public Boost[] AppearanceBoosts => _appearanceBoosts;
    public bool IsPurchased => _isPurchased;
    public bool IsSelected => _isSelected;
    public string Name => _name;
    public int Price => _price;
}
