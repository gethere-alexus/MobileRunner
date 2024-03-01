using Sources.Data;
using Sources.Player;
using Sources.ScriptableObjects;
using Sources.UI.Elements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.UI.Windows.Shop
{
    public class ItemBoostsDisplay : MonoBehaviour
    {
        [FormerlySerializedAs("_shopDisplay")] [FormerlySerializedAs("_shopPresenterDisplay")] [SerializeField] private SkinShopDisplay _skinShopDisplay;
        [SerializeField] private CharacterConfig _playerConfig;
        [SerializeField] private Transform _boostStorage;
        [SerializeField] private BoostDescription _boostDescriptionTemplate;

        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _skinShopDisplay.ShopInitialized += SubscribeSkinShopEvents;
        }

        private void SubscribeSkinShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _skinShopDisplay.SkinSkinShopInstance.NewItemPreviewed += OnNewItemShowed;
                _isShopEventsSubscribed = true;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _skinShopDisplay.SkinSkinShopInstance.NewItemPreviewed -= OnNewItemShowed;
                _isShopEventsSubscribed = false;
            }
        }

        private void OnNewItemShowed(ItemData skin) =>
            ConstructBoostsView(skin.ItemInformation);

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