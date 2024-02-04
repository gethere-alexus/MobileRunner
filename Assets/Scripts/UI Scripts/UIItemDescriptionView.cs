using Data_Scripts;
using Shop_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
    public class UIItemDescriptionView : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _charactersShopDisplay;
        [SerializeField] private TMP_Text _itemName, _itemDescription;
        [SerializeField] private Image _itemFrame;
        private void OnEnable()
        { 
            _charactersShopDisplay.OnNewItemPreviewed += ConfigureDescriptionUI;
        }
        private void OnDisable()
        {
            _charactersShopDisplay.OnNewItemPreviewed += ConfigureDescriptionUI;
        }
        private void ConfigureDescriptionUI(object sender, ItemData skin)
        {
            _itemFrame.sprite = skin.ItemInformation.ItemRarity.ItemFrame;
            _itemName.text = skin.ItemInformation.Name;
            //  _itemPrice.text = TextFormatter.DivideIntWithChar(skin.ItemInformation.Price, ',');
            _itemDescription.text = skin.ItemInformation.Description;
        }
    }
}
 