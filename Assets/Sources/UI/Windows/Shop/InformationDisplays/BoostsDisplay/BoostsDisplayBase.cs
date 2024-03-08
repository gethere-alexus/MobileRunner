using System;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;
using Infrastructure.Services.StaticData;
using Sources.Data;
using Sources.Player;
using Sources.StaticData;
using Sources.UI.Elements;
using UnityEngine;

namespace Sources.UI.Windows.Shop.InformationDisplays.BoostsDisplay
{
    public abstract class BoostsDisplayBase<TItem> : DisplayBase<TItem>, IDataReader where TItem : ItemStaticData
    {
        [SerializeField] private Transform _boostStorage;
        [SerializeField] private BoostDescription _boostDescriptionTemplate;

        [SerializeField] private float _displayDuration = 0.25f;

        private StatisticData[] _playerStats;

        protected override void ConstructDisplay(ItemData item)
        {
            ClearStorage();
            
            foreach (var boost in item.ItemInformation.AppliedBoosts)
                InstantiateBoost(boost);
        }

        public void LoadData(PlayerProgress progress)
        {
            IStaticDataProvider staticDataProvider = ServiceLocator.Container.Single<IStaticDataProvider>();

            int arrayLenght = Enum.GetNames(typeof(StatisticType)).Length;
            _playerStats = progress.StatValues;
        }

        private void InstantiateBoost(Boost boost)
        {
            StatisticData stat = Array.Find(_playerStats,
                statistic => statistic.StatType == boost.AplicableStatistic.Statistic);

            int valueWithApplying = stat.GetValueWithApplying(boost.BoostValue);

            Instantiate(_boostDescriptionTemplate, _boostStorage)
                .Construct(boost.AplicableStatistic.BoostSprite, boost.BoostValue, valueWithApplying,
                    _displayDuration);
        }

        private void ClearStorage()
        {
            if (_boostStorage.childCount != 0)
            {
                foreach (Transform description in _boostStorage)
                {
                    Destroy(description.gameObject);
                }
            }
        }
    }
}
