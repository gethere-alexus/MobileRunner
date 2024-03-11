using Sources.Data;
using Sources.Shop.Shop;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop
{
    public abstract class DisplayBase<TItem> : MonoBehaviour where TItem : ItemStaticData
    {
        protected IShopRepresenter<TItem> ShopRepresenter;
        private bool _isSubscribedOnShopInit, _isEventsSubscribed;

        private void Awake()
        {
            ShopRepresenter = GetComponent<IShopRepresenter<TItem>>();
        }

        private void OnEnable()
        {
            if (ShopRepresenter.ShopInstance != null)
                ConfigureStartDisplay();
            else
                SubscribeOnShopInit();
        }

        private void ConfigureStartDisplay()
        {
            SubscribeEvents();
            ConstructDisplay(ShopRepresenter.ShopInstance.ShowedItem);
        }

        protected virtual void SubscribeEvents()
        {
            ShopRepresenter.ShopInstance.NewItemPreviewed += ConstructDisplay;
            _isEventsSubscribed = true;
        }
        protected virtual void UnsubscribeEvents()
        {
            ShopRepresenter.ShopInstance.NewItemPreviewed -= ConstructDisplay;
            _isEventsSubscribed = false;
        }

        private void SubscribeOnShopInit()
        {
            ShopRepresenter.ShopInitialized += ConfigureStartDisplay;
            _isSubscribedOnShopInit = true;
        }

        private void UnsubscribeOnShopInit()
        {
            ShopRepresenter.ShopInitialized -= ConfigureStartDisplay;
            _isSubscribedOnShopInit = false;
        }

        private void OnDisable()
        {
            if(_isSubscribedOnShopInit)
                UnsubscribeOnShopInit();
            
            if (_isEventsSubscribed)
                UnsubscribeEvents();
        }

        protected virtual void ConstructDisplay(ItemData item)
        {
            
        }
    }
}