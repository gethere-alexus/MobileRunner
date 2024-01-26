using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDescriptionView : MonoBehaviour
{
    [SerializeField] private PlayerAppearance _playerAppearance;
    [SerializeField] private PlayerStatsRepresenter _playerStatsRepresenter;
    
    [SerializeField] private BoostDescription _boostDescriptionTemplate;

    [SerializeField] private Transform _boostStorage; 
    
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemPrice;
    
    [SerializeField] private Button _purchaseButton, _activeButton, _selectButton;

    private Button _buttonInstance;

    private void OnEnable()
    {
        _playerAppearance.OnNewSkinShowed += ConfigureUIAppearanceView;
    }

    private void OnDisable()
    {
        _playerAppearance.OnNewSkinShowed -= ConfigureUIAppearanceView;
    }

    private void ConfigureUIAppearanceView(object sender, Appearance information)
    {
        _itemName.text = information.Name;
        _itemPrice.text = TextFormatter.DivideIntWithChar(information.Price, ',');

        ConfigureBoostsView(information, _boostStorage);
        ConfigureButtonView(information);
    }
    private void ConfigureButtonView(Appearance ctx)
    {
        if (ctx.IsPurchased)
        { 
            Button assignButton = ctx.IsSelected ? _activeButton : _selectButton;
            SetButton(assignButton);
        }
        else
        {
            SetButton(_purchaseButton);
        }
    }
    private void SetButton(Button button)
    {
        if(_buttonInstance != null) _buttonInstance.gameObject.SetActive(false);
            
        _buttonInstance = button;
        _buttonInstance.gameObject.SetActive(true);
    }
    private void ConfigureBoostsView(Appearance ctx, Transform boostStorage)
    {
        if (_boostStorage.childCount != 0)
        {
            foreach (Transform description in boostStorage)
            {
                Destroy(description.gameObject);
            }
        }
        
        foreach (var boost in ctx.AppearanceBoosts)
        {
            PlayerStat playerStat = _playerStatsRepresenter.GetBoostRepresent(boost.BoostData.Boost);

            int valueAfterBoosting = playerStat.PreviewValueAfterApplying(boost.BoostValue);
            
            BoostDescription instance = Instantiate(_boostDescriptionTemplate, boostStorage);
        
            instance.ConfigureDescription(boost.BoostData.BoostSprite, boost.BoostValue, valueAfterBoosting);
        }
    }
}
 