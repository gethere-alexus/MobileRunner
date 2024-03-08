using Sources.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.InformationDisplays.ButtonsDisplay
{
    public abstract class ItemsSwitchBase<TItem> : DisplayBase<TItem> where TItem : ItemStaticData
    {
        [SerializeField] private Button _nextItemButton, _previousItemButton;

        protected override void SubscribeEvents()
        {
            _nextItemButton.onClick.AddListener(ShopRepresenter.ShopInstance.ShowNextItem);
            _previousItemButton.onClick.AddListener(ShopRepresenter.ShopInstance.ShowPreviousItem);
        }

        protected override void UnsubscribeEvents()
        {
            _nextItemButton.onClick.RemoveAllListeners();
            _previousItemButton.onClick.RemoveAllListeners();
        }
    }
}