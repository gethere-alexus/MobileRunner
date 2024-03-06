using Sources.Data;
using Sources.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.ItemInformation
{
    public class ItemDescriptionDisplay : MonoBehaviour
    {
        [SerializeField] private SkinShopRepresenter _skinShopRepresenter;
        [SerializeField] private TMP_Text _itemName, _itemDescription;
        [SerializeField] private Image _itemFrame;

        private void OnEnable()
        {
            _skinShopRepresenter.ShopInitialized += SubscribeSkinShopEvents;
            SubscribeSkinShopEvents();
        }

        private void SubscribeSkinShopEvents()
        {
            if (_skinShopRepresenter.SkinShopInstance != null)
            {
                _skinShopRepresenter.SkinShopInstance.NewItemPreviewed += ConstructDescription;
            }
        }

        private void OnDisable()
        {
            if (_skinShopRepresenter.SkinShopInstance != null)
            {
                _skinShopRepresenter.SkinShopInstance.NewItemPreviewed -= ConstructDescription;
            }
            _skinShopRepresenter.ShopInitialized -= SubscribeSkinShopEvents;
        }

        private void ConstructDescription(ItemData<SkinStaticData> skin)
        {
            _itemFrame.sprite = skin.ItemInformation.ItemRarity.ItemFrame;
            _itemName.text = skin.ItemInformation.Name;
            //  _itemPrice.text = TextFormatter.DivideIntWithChar(skin.ItemInformation.Price, ',');
            _itemDescription.text = skin.ItemInformation.Description;
        }
    }
}