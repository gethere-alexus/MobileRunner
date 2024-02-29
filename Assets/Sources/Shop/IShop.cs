using System;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Sources.Shop
{
    public interface IShop
    {
        void InitShop(SkinStaticData[] skins);
        Transform PreviewSpace { get; set; }
        event Action ShopInitialized;
    }
}