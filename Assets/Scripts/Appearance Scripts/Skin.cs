using UnityEngine;

namespace Appearance_Scripts
{
    public class Skin : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private int _price;
        [SerializeField] private ItemRarity _itemRarity;
    
        [SerializeField] private Boost[] _appliedBoosts;

        public Boost[] AppliedBoosts => _appliedBoosts;
        public string Name => _name;
        public int Price => _price;
        public string Description => _description;

        public ItemRarity ItemRarity => _itemRarity;
    }
}
