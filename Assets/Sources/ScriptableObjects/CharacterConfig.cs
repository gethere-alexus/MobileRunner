using ScriptableObjects;
using UnityEngine;

namespace Sources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private ItemDataContainer _skinDataContainer;

        public void SelectSkin(ItemDataContainer skinDataContainer)
        {
            _skinDataContainer = skinDataContainer;
        }

        public ItemDataContainer SkinDataContainer => _skinDataContainer;
    }
}