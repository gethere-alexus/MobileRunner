using System;
using Infrastructure.Data;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Sources.Shop
{
    public interface IShopRepresenter
    {
        Transform PreviewSpace { get; set; }
        SkinShop SkinSkinShopInstance { get; }
        event Action ShopInitialized;
        void InitShop(SkinStaticData[] skins, PlayerProgress initialProgress);
    }
}