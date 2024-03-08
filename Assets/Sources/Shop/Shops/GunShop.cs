using System;
using System.Linq;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;
using Sources.Data;
using Sources.Money;
using Sources.StaticData;
using Sources.StaticData.GunTypes;

namespace Sources.Shop.Shops
{
    public class GunShop : ShopBase<GunStaticData>
    {
        public GunShop(GunStaticData[] items, PlayerProgress initialProgress, IWallet walletInstance) : base(items,walletInstance,initialProgress)
        {
            
        }

        public override void ShowSelectedItem()
        {
            int index = Array.FindIndex(Items, item => item == SelectedItem);
            ShowItemByIndex(index);
        }

        public override void SelectShowedItem()
        {
            if (!PurchasedItems.Contains(PreviewedItem.ItemInformation as GunStaticData))
                return;

            ItemData overridingData =
                new ItemData(PreviewedItem.ItemInformation, ItemStatus.Selected);

            PreviewedItem = overridingData;
            SelectedItem = PreviewedItem.ItemInformation as GunStaticData;
            ShowSelectedItem();
            UpdateData();
        }

        public override void PurchaseShowedItem()
        {
            if (PreviewedItem.ItemStatus != ItemStatus.Purchasable) 
                return;
            
            if (WalletInstance.TrySpendMoney(PreviewedItem.ItemInformation.Price))
            {
                PurchasedItems.Add(PreviewedItem.ItemInformation as GunStaticData);
                SelectShowedItem();
                UpdateData();   
            }
        }

        public override void LoadData(PlayerProgress progress)
        {
            SetPurchasedGuns(progress);
            SetSelectedGuns(progress);
        }

        public override void UpdateData()
        {
            IProgressProvider progressProvider = ServiceLocator.Container.Single<IProgressProvider>();
            PlayerProgress progressCopy = progressProvider.GetProgress();

            progressCopy.PurchasedGuns = PurchasedItems.ToSerializableArray();
            progressCopy.SelectedGun = SelectedItem.ToSerializable();
            
            progressProvider.UpdateData(progressCopy);
        }

        private void SetSelectedGuns(PlayerProgress progress)
        {
            GunType selectedGunType = progress.SelectedGun;
            GunStaticData progressSelectedGun = Array.Find(Items, item => item.Gun == selectedGunType);

            if (SelectedItem != progressSelectedGun)
            {
                SelectedItem = progressSelectedGun;
                ShowSelectedItem();
            }
        }

        private void SetPurchasedGuns(PlayerProgress progress)
        {
            GunType[] purchasedGunData = progress.PurchasedGuns;
            PurchasedItems = Items.Where(data => purchasedGunData.Contains(data.Gun)).ToList();
        }
    }
}