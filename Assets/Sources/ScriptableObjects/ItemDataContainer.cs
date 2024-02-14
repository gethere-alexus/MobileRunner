using UnityEngine;

namespace ScriptableObjects
{
    public abstract class ItemDataContainer : ScriptableObject
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private int _price;
        [SerializeField] private ItemRarity _itemRarity;
        [SerializeField] private Boost[] _appliedBoosts;

        public GameObject ItemPrefab => _itemPrefab;
        public string Name => _name;
        public string Description => _description;
        public int Price => _price;
        public Boost[] AppliedBoosts => _appliedBoosts;
        public ItemRarity ItemRarity => _itemRarity;
    }
}
