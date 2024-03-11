using Sources.Data;
using Sources.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Shop.Shop
{
    public abstract class DescriptionDisplayBase<TItem> : DisplayBase<TItem> where TItem : ItemStaticData
    {
        
        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private TMP_Text _itemDescription;
        
        [SerializeField] private Image _itemFrame;

        protected override void ConstructDisplay(ItemData item)
        {
            _itemFrame.sprite = item.ItemInformation.ItemRarity.ItemFrame;
            _itemName.text = item.ItemInformation.Name;
            _itemDescription.text = item.ItemInformation.Description;
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            ShopRepresenter.ShopInstance.NewItemPreviewed += ConstructDisplay;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            ShopRepresenter.ShopInstance.NewItemPreviewed -= ConstructDisplay;
        }
    }
}