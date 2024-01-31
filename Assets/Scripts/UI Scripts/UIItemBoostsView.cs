using UnityEngine;
public class UIItemBoostsView : MonoBehaviour
{
    [SerializeField] private PlayerSkin _playerSkin;
    [SerializeField] private PlayerStatsRepresenter _playerStatsRepresenter;
    [SerializeField] private Transform _boostStorage;
    [SerializeField] private BoostDescription _boostDescriptionTemplate;
    
    private void OnEnable()
    { 
        _playerSkin.OnNewSkinShowed += OnNewSkinShowed;
    }

    private void OnDisable()
    {
        _playerSkin.OnNewSkinShowed -= OnNewSkinShowed;
    }
    private void OnNewSkinShowed(object sender, Skin skin) => ConfigureBoostsView(skin);
    private void ConfigureBoostsView(Skin skin)
    {
        if (_boostStorage.childCount != 0)
        {
            foreach (Transform description in _boostStorage)
            {
                Destroy(description.gameObject);
            }
        }
        
        foreach (var boost in skin.AppliedBoosts)
        {
            PlayerStat playerStat = _playerStatsRepresenter.GetBoostRepresent(boost.BoostData);

            int valueAfterBoosting = playerStat.DefaultBoostableValue + boost.BoostValue;
            
            BoostDescription instance = Instantiate(_boostDescriptionTemplate, _boostStorage);
        
            instance.ConfigureDescription(boost.BoostData.BoostSprite, boost.BoostValue, valueAfterBoosting);
        }
    }
}
