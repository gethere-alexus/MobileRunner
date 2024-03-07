using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.Shop;
using Sources.StaticData;
using UnityEngine;

namespace Sources.UI.Windows.Shop
{
    public class SkinShopRepresenter : MonoBehaviour, IShopRepresenter
    {
        public Transform PreviewSpace { get; set; }
 
        private SkinShop _skinSkinShopInstance;
        public event Action ShopInitialized;

        public void InitShop(SkinStaticData[] skins, PlayerProgress initialProgress, IWallet walletInstance)
        {
            _skinSkinShopInstance = new SkinShop(skins, walletInstance,initialProgress);
            ShopInitialized?.Invoke();
            _skinSkinShopInstance.ShowSelectedItem();
        }

        public SkinShop SkinShopInstance =>
            _skinSkinShopInstance;
        
    }
}