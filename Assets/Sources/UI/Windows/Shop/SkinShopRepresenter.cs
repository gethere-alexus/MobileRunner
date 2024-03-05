using System;
using Infrastructure.Data;
using Sources.Shop;
using Sources.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    public class SkinShopRepresenter : MonoBehaviour, IShopRepresenter
    {
        public Transform PreviewSpace { get; set; }
 
        private SkinShop _skinSkinShopInstance;
        public event Action ShopInitialized;

        public void InitShop(SkinStaticData[] skins, PlayerProgress initialProgress)
        {
            _skinSkinShopInstance = new SkinShop(skins, initialProgress);
            ShopInitialized?.Invoke();
            _skinSkinShopInstance.ShowItemByIndex(0);
        }

        public SkinShop SkinSkinShopInstance =>
            _skinSkinShopInstance;
    }
}