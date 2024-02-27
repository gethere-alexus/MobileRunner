using Sources.Player;
using UnityEngine;

namespace Sources.ScriptableObjects
{
    public abstract class ItemData : ScriptableObject
    {
        public string Name;
        [Min(0)]public int Price;
        public string Description;
        public ItemRarity ItemRarity;
        public Boost[] AppliedBoosts;
        public GameObject ItemPrefab;
    }
}