using Sources.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Shop
{
    public class ItemDescriptionDisplay : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _charactersShopDisplay;
        [SerializeField] private TMP_Text _itemName, _itemDescription;
        [SerializeField] private Image _itemFrame;

        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _charactersShopDisplay.ShopInitialized += SubscribeShopEvents;
        }

        private void SubscribeShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _charactersShopDisplay.SkinShopInstance.NewItemPreviewed += ConstructDescription;
                _isShopEventsSubscribed = true;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _charactersShopDisplay.SkinShopInstance.NewItemPreviewed -= ConstructDescription;
                _isShopEventsSubscribed = false;
            }
        }

        private void ConstructDescription(ItemData skin)
        {
            _itemFrame.sprite = skin.ItemStaticDataInformation.ItemRarity.ItemFrame;
            _itemName.text = skin.ItemStaticDataInformation.Name;
            //  _itemPrice.text = TextFormatter.DivideIntWithChar(skin.ItemInformation.Price, ',');
            _itemDescription.text = skin.ItemStaticDataInformation.Description;
        }
    }
}