using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.Shop.Shops;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop.ShopRepresenters
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
            _skinShopInstance.ShowSelectedItem();
        }

        public ShopBase<SkinStaticData> ShopInstance =>
            _skinShopInstance;
    }
}