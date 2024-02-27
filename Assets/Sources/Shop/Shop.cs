using System;
using System.Collections.Generic;
using Sources.ScriptableObjects;
using Sources.Utils;

namespace Sources.Shop
{
    public enum ItemStatus
    {
        Purchasable,
        Selectable,
        Selected
    }

    public class Shop
    {
        private readonly ItemData[] _items;
        private List<ItemData> _purchasedItems = new List<ItemData>();
        private Data.ItemData _previewedItem;
        private int _observingItemIndex = 0;

        private readonly CharacterConfig _playerConfig;

        public Shop(CharacterConfig playerConfig, ItemData[] itemsToPlaceInShop,
            ItemData[] purchasedItems = null)
        {
            _items = itemsToPlaceInShop;
            _playerConfig = playerConfig;
            if (purchasedItems != null)
            {
                foreach (var purchasedItem in purchasedItems)
                {
                    _purchasedItems.Add(purchasedItem);
                }
            }

            _items = Sorter.SortItemsByPrice<ItemData>(_items);
        }

        private Data.ItemData ConstructItemData(ItemData itemData)
        {
            ItemStatus itemStatus = ItemStatus.Purchasable;
            if (_purchasedItems.Contains(itemData))
            {
                itemStatus = ItemStatus.Selectable;
                if (_playerConfig.UsingSkin == itemData)
                {
                    itemStatus = ItemStatus.Selected;
                }
            }

            return new Data.ItemData(_items[_observingItemIndex], itemStatus);
        }

        public void PreviewItemByIndex(int index)
        {
            _observingItemIndex = index > _items.Length || index < 0 ? 0 : index;
            _previewedItem = ConstructItemData(_items[_observingItemIndex]);
        }

        public void PreviewNextItem()
        {
            _observingItemIndex = _observingItemIndex + 1 >= _items.Length ? 0 : _observingItemIndex + 1;
            PreviewItemByIndex(_observingItemIndex);
        }
        
        public void PreviewSelectedSkin()
        {
            _observingItemIndex = Array.FindIndex(_items, item => item == _playerConfig.UsingSkin);
            PreviewItemByIndex(_observingItemIndex);
        }

        public void PreviewPreviousSkin()
        {
            _observingItemIndex = _observingItemIndex - 1 < 0 ? _items.Length - 1 : _observingItemIndex - 1;
            PreviewItemByIndex(_observingItemIndex);
        }

        public void SelectShowedItem()
        {
            if (!_purchasedItems.Contains(_previewedItem.ItemDataInformation)) 
                return;
            
            Data.ItemData overridingData = new Data.ItemData(_previewedItem.ItemDataInformation, ItemStatus.Selected);
            
            _previewedItem = overridingData;
            _playerConfig.SelectSkin(_previewedItem.ItemDataInformation);
        }

        public void PurchaseShowedSkin()
        {
            if (_previewedItem.ItemStatus == ItemStatus.Purchasable)
            {
                _purchasedItems.Add(_previewedItem.ItemDataInformation);
                SelectShowedItem();
            }
        }

        public Data.ItemData PreviewedItem => _previewedItem;
    }
}