using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private AppearanceSwitcher _appearanceSwitcher;

    [SerializeField] private Skin[] _purchasedSkins;

    public event EventHandler<Skin> OnSkinPurchased; 

    public void PurchaseSelectedAppearance()
    {
        //OnSkinPurchased?.Invoke(this);
    }
}
