using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop
{
    public interface IShopRepresenter
    {
        Transform PreviewSpace { get; set; }
        SkinShop SkinShopInstance { get; }
        event Action ShopInitialized;
        void InitShop(SkinStaticData[] skins, PlayerProgress initialProgress, IWallet walletInstance);
    }
    
}