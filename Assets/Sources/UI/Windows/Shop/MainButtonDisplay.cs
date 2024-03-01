using Sources.Data;
using Sources.Shop;
using Sources.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    public class MainButtonDisplay : MonoBehaviour
    {
        [FormerlySerializedAs("_skinShopDisplay")] [SerializeField] private SkinShopRepresenter _skinShopRepresenter;
        [SerializeField] private Button _mainInteractionButton;
        [SerializeField] private TMP_Text _priceText;

        private void ConstructDescription(ItemData obj) //TODO: REFACTOR BUTTONS
        {
            _priceText.text = obj.ItemStatus switch
            {
                ItemStatus.Purchasable => TextFormatter.DivideIntWithChar(obj.ItemInformation.Price, ','),
                ItemStatus.Selectable => "Select",
                ItemStatus.Selected => "Selected",
                _ => _priceText.text
            };
        }

        private void OnEnable()
        {
            _skinShopRepresenter.ShopInitialized += SubscribeSkinShopEvents;
            SubscribeSkinShopEvents();
        }

        private void SubscribeSkinShopEvents()
        {
            if (_skinShopRepresenter.SkinSkinShopInstance != null)
            {
                _skinShopRepresenter.SkinSkinShopInstance.NewItemPreviewed += ConstructDescription;
            }
        }

        private void OnDisable()
        {
            if (_skinShopRepresenter.SkinSkinShopInstance != null)
            {
                _skinShopRepresenter.SkinSkinShopInstance.NewItemPreviewed -= ConstructDescription;
            }
            _skinShopRepresenter.ShopInitialized -= SubscribeSkinShopEvents;
        }
    }
}