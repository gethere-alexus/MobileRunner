using System;
using System.Collections.Generic;
using FMOD;
using Sources.Data;
using Sources.ScriptableObjects;
using Sources.Utils;
using Debug = UnityEngine.Debug;

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
        private readonly Item[] _items;
        private List<Item> _purchasedItems = new List<Item>();
        private ItemData _previewedItem;
        private int _observingItemIndex = 0;

        private readonly CharacterConfig _playerConfig;

        public Shop(CharacterConfig playerConfig, Item[] itemsToPlaceInShop,
            Item[] purchasedItems = null)
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

            _items = Sorter.SortItemsByPrice<Item>(_items);
        }

        private ItemData ConstructItemData(Item item)
        {
            ItemStatus itemStatus = ItemStatus.Purchasable;
            if (_purchasedItems.Contains(item))
            {
                itemStatus = ItemStatus.Selectable;
                if (_playerConfig.UsingSkin == item)
                {
                    itemStatus = ItemStatus.Selected;
                }
            }

            return new ItemData(_items[_observingItemIndex], itemStatus);
        }

        public void PreviewItemByIndex(int index)
        {
            _observingItemIndex = index > _items.Length || index < 0 ? 0 : index;
            _previewedItem = ConstructItemData(_items[_observingItemIndex]);
            Debug.Log($"{_previewedItem.ItemInformation.Name} selected");
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
            if (!_purchasedItems.Contains(_previewedItem.ItemInformation)) 
                return;
            
            ItemData overridingData = new ItemData(_previewedItem.ItemInformation, ItemStatus.Selected);
            
            _previewedItem = overridingData;
            _playerConfig.SelectSkin(_previewedItem.ItemInformation);
        }

        public void PurchaseShowedSkin()
        {
            if (_previewedItem.ItemStatus == ItemStatus.Purchasable)
            {
                _purchasedItems.Add(_previewedItem.ItemInformation);
                SelectShowedItem();
            }
        }

        public ItemData PreviewedItem => _previewedItem;
    }
}