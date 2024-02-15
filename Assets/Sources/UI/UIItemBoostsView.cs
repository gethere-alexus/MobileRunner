using ScriptableObjects;
using Sources.Data;
using Sources.Player;
using Sources.ScriptableObjects;
using Sources.Shop;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.UI
{
    public class UIItemBoostsView : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _shopDisplay;
        [FormerlySerializedAs("_playerStatsRepresenter")] [SerializeField] private PlayerStatsRepresent _playerStatsRepresent;
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

        private void OnNewItemShowed(object sender, ItemData skin) => ConfigureBoostsView(skin.ItemInformation);

        private void ConfigureBoostsView(ItemDataContainer item)
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
                PlayerStat playerStat = _playerStatsRepresent.GetBoostRepresent(boost.BoostData);

                int valueAfterBoosting = playerStat.DefaultBoostableValue + boost.BoostValue;

                BoostDescription instance = Instantiate(_boostDescriptionTemplate, _boostStorage);

                instance.ConfigureDescription(boost.BoostData.BoostSprite, boost.BoostValue, valueAfterBoosting);
            }
        }
    }
}