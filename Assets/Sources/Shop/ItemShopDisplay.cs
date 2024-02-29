using System;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Sources.Shop
{
    public class ItemShopDisplay : MonoBehaviour, IShop
    {
        public Transform PreviewSpace { get; set; }
 
        private Shop _skinShopInstance;
        public event Action ShopInitialized;

        public void InitShop(SkinStaticData[] skins)
        {
            _skinShopInstance = new Shop(skins);
            ShopInitialized?.Invoke();
            _skinShopInstance.ShowItemByIndex(0);
            Debug.Log(PreviewSpace);
        }

        public Shop SkinShopInstance =>
            _skinShopInstance;
    }
}