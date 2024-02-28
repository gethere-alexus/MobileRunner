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
        private readonly ItemStaticData[] _items;
        private List<ItemStaticData> _purchasedItems = new List<ItemStaticData>();
        private Data.ItemData _previewedItem;
        private int _observingItemIndex = 0;

        private readonly CharacterConfig _playerConfig;

        public Shop(CharacterConfig playerConfig, ItemStaticData[] itemsToPlaceInShop,
            ItemStaticData[] purchasedItems = null)
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

            _items = Sorter.SortItemsByPrice<ItemStaticData>(_items);
        }

        private Data.ItemData ConstructItemData(ItemStaticData itemStaticData)
        {
            ItemStatus itemStatus = ItemStatus.Purchasable;
            if (_purchasedItems.Contains(itemStaticData))
            {
                itemStatus = ItemStatus.Selectable;
                if (_playerConfig.UsingSkin == itemStaticData)
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
            if (!_purchasedItems.Contains(_previewedItem.ItemStaticDataInformation)) 
                return;
            
            Data.ItemData overridingData = new Data.ItemData(_previewedItem.ItemStaticDataInformation, ItemStatus.Selected);
            
            _previewedItem = overridingData;
            _playerConfig.SelectSkin(_previewedItem.ItemStaticDataInformation);
        }

        public void PurchaseShowedSkin()
        {
            if (_previewedItem.ItemStatus == ItemStatus.Purchasable)
            {
                _purchasedItems.Add(_previewedItem.ItemStaticDataInformation);
                SelectShowedItem();
            }
        }

        public Data.ItemData PreviewedItem => _previewedItem;
    }
}