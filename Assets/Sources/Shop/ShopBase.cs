using System;
using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Sources.Data;
using Sources.ScriptableObjects;

namespace Sources.Shop
{
    public abstract class ShopBase : IDataWriter
    {
        protected readonly ItemStaticData[] Items;
        protected List<ItemStaticData> PurchasedItems = new();

        protected ItemData PreviewedItem;
        protected ItemStaticData SelectedItem;

        private int _observingItemIndex;

        public event Action<ItemData> NewItemPreviewed;

        protected ShopBase(ItemStaticData[] items) =>
            Items = items;

        public void ShowItemByIndex(int index)
        {
            _observingItemIndex = index > Items.Length || index < 0 ? 0 : index;
            PreviewedItem = ConstructItemData(Items[_observingItemIndex]);
            NewItemPreviewed?.Invoke(PreviewedItem);
        }

        public void ShowNextItem()
        {
            int index = _observingItemIndex + 1 >= Items.Length ? 0 : _observingItemIndex + 1;
            ShowItemByIndex(index);
        }

        public void ShowPreviousItem()
        {
            int index = _observingItemIndex - 1 < 0 ? Items.Length - 1 : _observingItemIndex - 1;
            ShowItemByIndex(index);
        }

        public abstract void ShowSelectedItem();
        public abstract void SelectShowedItem();
        public abstract void PurchaseShowedItem();
        public abstract void LoadData(PlayerProgress progress);
        public abstract void UpdateData();

        private ItemData ConstructItemData(ItemStaticData itemStaticData)
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

            return new ItemData(Items[_observingItemIndex], itemStatus);
        }
    }
}