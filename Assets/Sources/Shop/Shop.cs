using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Sources.Data;
using Sources.ScriptableObjects;

namespace Sources.Shop
{
    public class Shop : IDataWriter
    {
        private readonly ItemStaticData[] _items;
        private List<ItemStaticData> _purchasedItems = new List<ItemStaticData>();
        private ItemData _previewedItem;
        private ItemStaticData _selectedItem;
        private int _observingItemIndex = 0;
        public event Action<ItemData> NewItemPreviewed;

        public Shop(ItemStaticData[] items) => 
            _items = items;

        public void ShowItemByIndex(int index)
        {
            _observingItemIndex = index > _items.Length || index < 0 ? 0 : index;
            _previewedItem = ConstructItemData(_items[_observingItemIndex]);
            NewItemPreviewed?.Invoke(_previewedItem);
        }

        public void ShowNextItem()
        {
            _observingItemIndex = _observingItemIndex + 1 >= _items.Length ? 0 : _observingItemIndex + 1;
            ShowItemByIndex(_observingItemIndex);
        }

        public void ShowSelectedSkin()
        {
            // _observingItemIndex = Array.FindIndex(_items, item => item == _playerConfig.UsingSkin);
            // PreviewItemByIndex(_observingItemIndex);
        }

        public void ShowPreviousSkin()
        {
            _observingItemIndex = _observingItemIndex - 1 < 0 ? _items.Length - 1 : _observingItemIndex - 1;
            ShowItemByIndex(_observingItemIndex);
        }

        public void SelectShowedItem()
        {
            if (!_purchasedItems.Contains(_previewedItem.ItemStaticDataInformation))
                return;

            ItemData overridingData =
                new ItemData(_previewedItem.ItemStaticDataInformation, ItemStatus.Selected);

            _previewedItem = overridingData;
            //_playerConfig.SelectSkin(_previewedItem.ItemStaticDataInformation);
        }

        public void PurchaseShowedSkin()
        {
            if (_previewedItem.ItemStatus == ItemStatus.Purchasable)
            {
                _purchasedItems.Add(_previewedItem.ItemStaticDataInformation);
                SelectShowedItem();
            }
        }

        public void LoadData(PlayerProgress progress)
        {
            // Set purchased skins
            string[] purchasedSkinsData = progress.PurchasedSkins;
            _purchasedItems = _items.Where(data => purchasedSkinsData.Contains(data.Name)).ToList();
            
            // Set selected skin
            string selectedSkin = progress.SelectedSkin;
            _selectedItem = _items.First(item => item.Name == selectedSkin);
        }

        public void UpdateData()
        {
            
        }

        private ItemData ConstructItemData(ItemStaticData itemStaticData)
        {
            ItemStatus itemStatus = ItemStatus.Purchasable;
            if (_purchasedItems.Contains(itemStaticData))
            {
                itemStatus = ItemStatus.Selectable;
                if (_selectedItem == itemStaticData)
                {
                    itemStatus = ItemStatus.Selected;
                }
            }

            return new ItemData(_items[_observingItemIndex], itemStatus);
        }

        public ItemData PreviewedItem => _previewedItem;
    }
}