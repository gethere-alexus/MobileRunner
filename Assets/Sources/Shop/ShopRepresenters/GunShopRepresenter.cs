using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.Shop.Shops;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop.ShopRepresenters
{
    public class GunShopRepresenter : MonoBehaviour, IShopRepresenter<GunStaticData>
    {
        public Transform PreviewSpace { get; set; }
        private ShopBase<GunStaticData> _shopInstance;
        public event Action ShopInitialized;
        public void InitShop(GunStaticData[] items, PlayerProgress initialProgress, IWallet walletInstance)
        {
            _shopInstance = new GunShop(items, initialProgress, walletInstance);
            ShopInitialized?.Invoke();
            _shopInstance.ShowSelectedItem();
        }

        public ShopBase<GunStaticData> ShopInstance => 
            _shopInstance;
    }
}