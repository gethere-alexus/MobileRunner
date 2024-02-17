using Sources.Data;
using Sources.Player;
using Sources.ScriptableObjects;
using Sources.UI;
using UnityEngine;

namespace Sources.Shop
{
    public class ItemBoostsDisplay : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _shopDisplay;
        [SerializeField] private CharacterConfig _playerConfig;
        [SerializeField] private Transform _boostStorage;
        [SerializeField] private BoostDescription _boostDescriptionTemplate;
        
        private void OnEnable()
        {
            _shopDisplay.OnNewItemPreviewed += OnNewItemShowed;
        }

        private void OnDisable()
        {
            _shopDisplay.OnNewItemPreviewed -= OnNewItemShowed;
        }

        private void OnNewItemShowed(object sender, ItemData skin) =>
            ConstructBoostsView(skin.ItemInformation);

        private void ConstructBoostsView(ItemDataContainer item)
        {
            if (_boostStorage.childCount != 0)
            {
                foreach (Transform description in _boostStorage)
                {
                    Destroy(description.gameObject);
                }
            }

            foreach (var boost in item.AppliedBoosts)
            {
                Statistic stat = _playerConfig.GetStatInformation(boost.BoostData);
                int valueAfterBoosting = stat.PreviewValueAfterApplying(boost.BoostValue);

                Instantiate(_boostDescriptionTemplate, _boostStorage)
                    .Construct(boost.BoostData.BoostSprite, boost.BoostValue, valueAfterBoosting);
            }
        }
    }
}