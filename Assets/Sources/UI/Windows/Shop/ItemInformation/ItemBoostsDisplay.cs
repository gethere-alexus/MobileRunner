using System;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Sources.Data;
using Sources.Player;
using Sources.StaticData;
using Sources.UI.Elements;
using UnityEngine;

namespace Sources.UI.Windows.Shop.ItemInformation
{
    public class ItemBoostsDisplay : MonoBehaviour, IDataReader
    {
        [SerializeField] private SkinShopRepresenter _itemShopRepresenter;
        [SerializeField] private Transform _boostStorage;
        [SerializeField] private BoostDescription _boostDescriptionTemplate;

        private Statistic[] _playerStats;

        private void OnEnable()
        {
            _itemShopRepresenter.ShopInitialized += SubscribeItemShopEvents;
            SubscribeItemShopEvents();
        }

        private void SubscribeItemShopEvents()
        {
            if (_itemShopRepresenter.SkinShopInstance != null)
            {
                _itemShopRepresenter.SkinShopInstance.NewItemPreviewed += OnNewItemShowed;
            }
        }

        private void OnDisable()
        {
            if (_itemShopRepresenter.SkinShopInstance != null)
            {
                _itemShopRepresenter.SkinShopInstance.NewItemPreviewed -= OnNewItemShowed;
            }

            _itemShopRepresenter.ShopInitialized -= SubscribeItemShopEvents;
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
                Statistic stat = Array.Find(_playerStats,
                    statistic => statistic.StatDescription == boost.AplicableStatistic);

                int valueWithApplying = stat.GetValueWithApplying(boost.BoostValue);

                Instantiate(_boostDescriptionTemplate, _boostStorage)
                    .Construct(boost.AplicableStatistic.BoostSprite, boost.BoostValue, valueWithApplying);
            }
        }

        public void LoadData(PlayerProgress progress) =>
            _playerStats = progress.PlayerStatistics;
    }
}