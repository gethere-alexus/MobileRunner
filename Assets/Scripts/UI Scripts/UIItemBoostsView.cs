using ScriptableObjects;
using UnityEngine;
public class UIItemBoostsView : MonoBehaviour
{
    [SerializeField] private ItemShopDisplay _shopDisplay;
    [SerializeField] private PlayerStatsRepresenter _playerStatsRepresenter;
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
    private void OnNewItemShowed(object sender, ItemDataContainer skin) => ConfigureBoostsView(skin);
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
            PlayerStat playerStat = _playerStatsRepresenter.GetBoostRepresent(boost.BoostData);

            int valueAfterBoosting = playerStat.DefaultBoostableValue + boost.BoostValue;
            
            BoostDescription instance = Instantiate(_boostDescriptionTemplate, _boostStorage);
        
            instance.ConfigureDescription(boost.BoostData.BoostSprite, boost.BoostValue, valueAfterBoosting);
        }
    }
}
