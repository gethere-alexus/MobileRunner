using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.Shop.Shop;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop.SkinShop
{
    public class SkinShopRepresenter : MonoBehaviour, IShopRepresenter<SkinStaticData>
    {
        public Transform PreviewSpace { get; set; }

        private ShopBase<SkinStaticData> _skinShopInstance;
        public event Action ShopInitialized;

        public void InitShop(SkinStaticData[] skins, PlayerProgress initialProgress, IWallet walletInstance)
        {
            _skinShopInstance = new SkinShop(skins, walletInstance, initialProgress);
            ShopInitialized?.Invoke();
        }

        public ShopBase<SkinStaticData> ShopInstance =>
            _skinShopInstance;
    }
}