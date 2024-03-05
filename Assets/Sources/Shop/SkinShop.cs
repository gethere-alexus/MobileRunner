using System;
using System.Linq;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;
using Sources.Data;
using Sources.Money;
using Sources.StaticData;
using Sources.StaticData.CharacterTypes;

namespace Sources.Shop
{
    public sealed class SkinShop : ShopBase<SkinStaticData>
    {
        public SkinShop(SkinStaticData[] items, IWallet wallet, PlayerProgress initProgress = null) : base(items, wallet, initProgress)
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

            ItemData<SkinStaticData> overridingData =
                new ItemData<SkinStaticData>(PreviewedItem.ItemInformation, ItemStatus.Selected);

            PreviewedItem = overridingData;
            SelectedItem = PreviewedItem.ItemInformation;
            ShowSelectedItem();
            UpdateData();
        }

        public override void PurchaseShowedItem()
        {
            if (PreviewedItem.ItemStatus != ItemStatus.Purchasable) 
                return;
            
            if (WalletInstance.TrySpendMoney(PreviewedItem.ItemInformation.Price))
            {
                PurchasedItems.Add(PreviewedItem.ItemInformation);
                SelectShowedItem();
                UpdateData();   
            }
        }

        public override void LoadData(PlayerProgress progress)
        {
            // Set purchased skins
            CharacterType[] purchasedSkinsData = progress.PurchasedSkins;
            PurchasedItems = Items.Where(data => purchasedSkinsData.Contains(data.Character)).ToList();

            // Set selected skin
            CharacterType selectedSkin = progress.SelectedSkin;
            SelectedItem = Items.First(item => selectedSkin == item.Character);
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