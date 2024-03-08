using Sources.Data;
using Sources.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.InformationDisplays.DescriptionDisplay
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
    }
}