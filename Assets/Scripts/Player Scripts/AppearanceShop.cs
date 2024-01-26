using System;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceShop : MonoBehaviour
{
    [SerializeField] private AppearanceSwitcher _appearanceSwitcher;
    
    [SerializeField] private List<Head> _purchasedHeads;
    [SerializeField] private List<Body> _purchasedBodies;
    [SerializeField] private List<Weapon> _purchasedWeapons;

    public event EventHandler<Appearance> OnSkinPurchased; 

    private void Start()
    {
        foreach (var item in _purchasedHeads)
        {
            item.PurchaseAppearance();
        }
        foreach (var item in _purchasedBodies)
        {
            item.PurchaseAppearance();
        }
        foreach (var item in _purchasedWeapons)
        {
            item.PurchaseAppearance();
        }
    }

    public void PurchaseSelectedAppearance()
    {
        Appearance appearance = _appearanceSwitcher.ShowedAppearance;
        appearance.PurchaseAppearance();
        
        switch (appearance)
        {
            case Head head when !_purchasedHeads.Contains(head):
                _purchasedHeads.Add(head);
                break;
            case Body body when !_purchasedBodies.Contains(body):
                _purchasedBodies.Add(body);
                break;
            case Weapon weapon when !_purchasedWeapons.Contains(weapon):
                _purchasedWeapons.Add(weapon);
                break;
        }
        
        OnSkinPurchased?.Invoke(this, appearance);
    }

    public List<Head> PurchasedHeads => _purchasedHeads;
    public List<Body> PurchasedBodies => _purchasedBodies;
    public List<Weapon> PurchasedWeapons => _purchasedWeapons;
}
