using Sources.Player;
using UnityEngine;

namespace Sources.StaticData
{
    public abstract class ItemStaticData : ScriptableObject
    {
        public string Name;
        [Min(0)]public int Price;
        public string Description;
        public ItemRarity ItemRarity;
        public Boost[] AppliedBoosts;
        public GameObject ItemPrefab;
    }
}