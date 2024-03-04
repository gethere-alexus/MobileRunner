using System;
using System.Linq;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;
using Sources.Data;
using Sources.StaticData;

namespace Sources.Shop
{
    public sealed class SkinShop : ShopBase
    {
        public SkinShop(ItemStaticData[] items, PlayerProgress initProgress = null) : base(items, initProgress)
        {
        }

        public override void ShowSelectedItem()
        {
            int index = Array.FindIndex(Items, item => item == SelectedItem);
            ShowItemByIndex(index);
        }

        public override void SelectShowedItem()
        {
            if (!PurchasedItems.Contains(PreviewedItem.ItemInformation))
                return;

            ItemData overridingData =
                new ItemData(PreviewedItem.ItemInformation, ItemStatus.Selected);

            PreviewedItem = overridingData;
            SelectedItem = PreviewedItem.ItemInformation;
            UpdateData();
        }

        public override void PurchaseShowedItem()
        {
            if (PreviewedItem.ItemStatus == ItemStatus.Purchasable)
            {
                PurchasedItems.Add(PreviewedItem.ItemInformation);
                SelectShowedItem();
                UpdateData();
            }
        }

        public override void LoadData(PlayerProgress progress)
        {
            // Set purchased skins
            string[] purchasedSkinsData = progress.PurchasedSkins;
            PurchasedItems = Items.Where(data => purchasedSkinsData.Contains(data.Name)).ToList();

            // Set selected skin
            string selectedSkin = progress.SelectedSkin;
            SelectedItem = Items.First(item => item.Name == selectedSkin);
        }

        public override void UpdateData()
        {
            IProgressProvider progressProvider = ServiceLocator.Container.Single<IProgressProvider>();
            PlayerProgress progressCopy = progressProvider.GetProgress();
            
            progressCopy.PurchasedSkins = PurchasedItems.ToSerializableArray();
            progressCopy.SelectedSkin = SelectedItem.ToSerializable();
            
            progressProvider.UpdateData(progressCopy);
        }
    }
}