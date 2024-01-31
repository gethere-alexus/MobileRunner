using UnityEngine;
public class Skin : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
    [SerializeField] protected int _price;
    [SerializeField] private ItemRarity _itemRarity;
    
    [SerializeField] protected Boost[] _appliedBoosts;

    public Boost[] AppliedBoosts => _appliedBoosts;
    public string Name => _name;
    public int Price => _price;
    public string Description => _description;

    public ItemRarity ItemRarity => _itemRarity;
}
