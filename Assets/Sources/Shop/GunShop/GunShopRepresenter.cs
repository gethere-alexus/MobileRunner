using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.Shop.Shop;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop.GunShop
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
        }

        private void OnEnable()
        {
            if (_shopInstance != null)
                _shopInstance.ShowSelectedItem();
        }

        public ShopBase<GunStaticData> ShopInstance => 
            _shopInstance;
    }
}