using System;
using Infrastructure.Data;
using Sources.Money;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop.Shop
{
    public interface IShopRepresenter<TItem> where TItem : ItemStaticData
    {
        Transform PreviewSpace { get; set; }
        ShopBase<TItem> ShopInstance { get; }
        event Action ShopInitialized;
        void InitShop(TItem[] items, PlayerProgress initialProgress, IWallet walletInstance);
    }
}