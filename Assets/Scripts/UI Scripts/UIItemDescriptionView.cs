using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
    public class UIItemDescriptionView : MonoBehaviour
    {
        [SerializeField] private CharactersShopDisplay _charactersShopDisplay;
    
        [SerializeField] private TMP_Text _itemName, _itemPrice, _itemDescription;
        [SerializeField] private Image _itemFrame;
        private void OnEnable()
        { 
            _charactersShopDisplay.SkinShopInstance.OnNewItemPreviewed += ConfigureDescriptionUI;
        }
        private void OnDisable()
        {
            _charactersShopDisplay.SkinShopInstance.OnNewItemPreviewed += ConfigureDescriptionUI;
        }
        private void ConfigureDescriptionUI(object sender, ItemDataContainer skin)
        {
            _itemFrame.sprite = skin.ItemRarity.ItemFrame;
            _itemName.text = skin.Name;
            _itemPrice.text = TextFormatter.DivideIntWithChar(skin.Price, ',');
            _itemDescription.text = skin.Description;
        }
    }
}
 