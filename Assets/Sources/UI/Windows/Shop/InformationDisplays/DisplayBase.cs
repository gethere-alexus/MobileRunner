using Sources.Data;
using Sources.Shop.ShopRepresenters;
using Sources.StaticData;
using UnityEngine;

namespace Sources.UI.Windows.Shop.InformationDisplays
{
    public abstract class DisplayBase<TItem> : MonoBehaviour where TItem : ItemStaticData
    {
        protected IShopRepresenter<TItem> ShopRepresenter;

        private void Awake()
        {
            ShopRepresenter = GetComponent<IShopRepresenter<TItem>>();
        }

        private void OnEnable()
        {
            if (ShopRepresenter != null)
                ShopRepresenter.ShopInitialized += SubscribeEvents;
            
            SubscribeEvents();
        }

        protected virtual void SubscribeEvents()
        {
            if (ShopRepresenter.ShopInstance != null)
                ShopRepresenter.ShopInstance.NewItemPreviewed += ConstructDisplay;
        }

        protected virtual void UnsubscribeEvents()
        {
            ShopRepresenter.ShopInstance.NewItemPreviewed -= ConstructDisplay;
        }

        private void OnDisable()
        {
            if (ShopRepresenter.ShopInstance != null)
                UnsubscribeEvents();
            
            if (ShopRepresenter != null)
                ShopRepresenter.ShopInitialized -= SubscribeEvents;
        }

        protected virtual void ConstructDisplay(ItemData item)
        {
            
        }
    }
}