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

        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _shopDisplay.ShopInitialized += SubscribeShopEvents;
        }

        private void SubscribeShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _shopDisplay.SkinShopInstance.NewItemPreviewed += OnNewItemShowed;
                _isShopEventsSubscribed = true;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _shopDisplay.SkinShopInstance.NewItemPreviewed -= OnNewItemShowed;
                _isShopEventsSubscribed = false;
            }
        }

        private void OnNewItemShowed(ItemData skin) =>
            ConstructBoostsView(skin.ItemStaticDataInformation);

        private void ConstructBoostsView(ItemStaticData itemStaticData)
        {
            if (_boostStorage.childCount != 0)
            {
                foreach (Transform description in _boostStorage)
                {
                    Destroy(description.gameObject);
                }
            }

            foreach (var boost in itemStaticData.AppliedBoosts)
            {
                Statistic stat = _playerConfig.GetStatInformation(boost.BoostData);
                int valueAfterBoosting = stat.PreviewValueAfterApplying(boost.BoostValue);

                Instantiate(_boostDescriptionTemplate, _boostStorage)
                    .Construct(boost.BoostData.BoostSprite, boost.BoostValue, valueAfterBoosting);
            }
        }
    }
}