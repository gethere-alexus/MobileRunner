using System;
using Appearance_Scripts;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Skin[] _availableToPurchaseSkins, _purchasedSkins;

    public event EventHandler<Skin> OnSkinPurchased;

    private void Awake()
    {
        _availableToPurchaseSkins = Sorter.SortPartByPrice(_availableToPurchaseSkins);
    }

    public void PurchaseSelectedAppearance()
    {
    }

    public Skin[] AvailableToPurchaseSkins => _availableToPurchaseSkins;
}
