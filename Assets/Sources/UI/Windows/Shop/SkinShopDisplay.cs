using System;
using Sources.ScriptableObjects;
using Sources.Shop;
using UnityEngine;

namespace Sources.UI.Windows.Shop
{
    public class SkinShopDisplay : MonoBehaviour, IShopPresenter
    {
        public Transform PreviewSpace { get; set; }
 
        private SkinShop _skinSkinShopInstance;
        public event Action ShopInitialized;

        public void InitShop(SkinStaticData[] skins)
        {
            _skinSkinShopInstance = new SkinShop(skins);
            ShopInitialized?.Invoke();
            _skinSkinShopInstance.ShowItemByIndex(0);
        }

        public SkinShop SkinSkinShopInstance =>
            _skinSkinShopInstance;
    }
}