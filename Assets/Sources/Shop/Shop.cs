using System.Collections.Generic;
using ScriptableObjects;
using Sources.Data;
using Sources.ScriptableObjects;
using Sources.Utils;
using UnityEngine;

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
        private readonly ItemDataContainer[] _items;
        private List<ItemDataContainer> _purchasedItems = new List<ItemDataContainer>();
        private ItemData _previewedItem;
        private int _observingItemIndex = 0;

        private readonly CharacterConfig _playerConfig;

        public Shop(CharacterConfig playerConfig, ItemDataContainer[] itemsToPlaceInShop,
            ItemDataContainer[] purchasedItems = null)
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

            _items = Sorter.SortSkinsByPrice(_items);
        }

        private ItemData ConfigureItemData(ItemDataContainer itemDataContainer)
        {
            ItemStatus itemStatus = ItemStatus.Purchasable;
            if (_purchasedItems.Contains(itemDataContainer))
            {
                itemStatus = ItemStatus.Selectable;
                if (_playerConfig.SkinDataContainer == itemDataContainer)
                {
                    itemStatus = ItemStatus.Selected;
                }
            }

            return new ItemData(_items[_observingItemIndex], itemStatus);
        }

        public void PreviewItemByIndex(int index)
        {
            _observingItemIndex = index > _items.Length || index < 0 ? 0 : index;
            _previewedItem = ConfigureItemData(_items[_observingItemIndex]);
        }

        public void PreviewItemSkin()
        {
            _observingItemIndex = _observingItemIndex + 1 >= _items.Length ? 0 : _observingItemIndex + 1;
            PreviewItemByIndex(_observingItemIndex);
        }

        public void PreviewPreviousSkin()
        {
            _observingItemIndex = _observingItemIndex - 1 < 0 ? _items.Length - 1 : _observingItemIndex - 1;
            PreviewItemByIndex(_observingItemIndex);
        }

        public void SelectShowedItem()
        {
            Debug.Log("Selected");
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