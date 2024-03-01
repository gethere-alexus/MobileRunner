using System;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Sources.Shop
{
    public interface IShopPresenter
    {
        void InitShop(SkinStaticData[] skins);
        Transform PreviewSpace { get; set; }
        event Action ShopInitialized;
    }
}