using Sources.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    public class ItemDescriptionDisplay : MonoBehaviour
    {
        [FormerlySerializedAs("_charactersShopDisplay")] [FormerlySerializedAs("_charactersShopPresenterDisplay")] [SerializeField] private SkinShopDisplay _charactersSkinShopDisplay;
        [SerializeField] private TMP_Text _itemName, _itemDescription;
        [SerializeField] private Image _itemFrame;

        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _charactersSkinShopDisplay.ShopInitialized += SubscribeSkinShopEvents;
        }

        private void SubscribeSkinShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _charactersSkinShopDisplay.SkinSkinShopInstance.NewItemPreviewed += ConstructDescription;
                _isShopEventsSubscribed = true;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _charactersSkinShopDisplay.SkinSkinShopInstance.NewItemPreviewed -= ConstructDescription;
                _isShopEventsSubscribed = false;
            }
        }

        private void ConstructDescription(ItemData skin)
        {
            _itemFrame.sprite = skin.ItemInformation.ItemRarity.ItemFrame;
            _itemName.text = skin.ItemInformation.Name;
            //  _itemPrice.text = TextFormatter.DivideIntWithChar(skin.ItemInformation.Price, ',');
            _itemDescription.text = skin.ItemInformation.Description;
        }
    }
}