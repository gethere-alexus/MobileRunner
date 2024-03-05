using System;
using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Sources.Data;
using Sources.Money;
using Sources.StaticData;

namespace Sources.Shop
{
    public abstract class ShopBase<TItem> : IDataWriter where TItem : ItemStaticData
    {
        protected readonly IWallet WalletInstance;
        protected readonly TItem[] Items;
        protected List<TItem> PurchasedItems = new();

        protected ItemData<TItem> PreviewedItem;
        protected TItem SelectedItem;

        private int _observingItemIndex = 0;

        public event Action<ItemData<TItem>> NewItemPreviewed;

        protected ShopBase(TItem[] items, IWallet wallet, PlayerProgress initProgress = null)
        {
            Items = items;
            WalletInstance = wallet;
            LoadData(initProgress);
        }

        public void ShowItemByIndex(int index)
        {
            _observingItemIndex = index > Items.Length || index < 0 ? 0 : index;
            PreviewedItem = ConstructItemData(Items[_observingItemIndex]);
            NewItemPreviewed?.Invoke(PreviewedItem);
        }

        public void ShowNextItem()
        {
            _observingItemIndex = _observingItemIndex + 1 >= Items.Length ? 0 : _observingItemIndex + 1;
            ShowItemByIndex(_observingItemIndex);
        }

        public void ShowPreviousItem()
        {
            _observingItemIndex = _observingItemIndex - 1 < 0 ? Items.Length - 1 : _observingItemIndex - 1;
            ShowItemByIndex(_observingItemIndex);
        }

        public abstract void ShowSelectedItem();
        public abstract void SelectShowedItem();
        public abstract void PurchaseShowedItem();
        public abstract void LoadData(PlayerProgress progress);
        public abstract void UpdateData();

        private ItemData<TItem> ConstructItemData(TItem itemStaticData)
        {
            ItemStatus itemStatus = ItemStatus.Purchasable;
            if (PurchasedItems.Contains(itemStaticData))
            {
                itemStatus = ItemStatus.Selectable;
                if (SelectedItem == itemStaticData)
                {
                    itemStatus = ItemStatus.Selected;
                }
            }

            return new ItemData<TItem>(Items[_observingItemIndex], itemStatus);
        }

        public ItemData<TItem> ShowedItem => PreviewedItem;
    }
}