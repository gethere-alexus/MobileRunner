using System;
using UnityEngine;
public class PlayerAppearance : MonoBehaviour
{
    [SerializeField] private AppearanceShop _appearanceShop;
    
    private Head _selectedHead, _showedHead;
    private Body _selectedBody, _showedBody;
    private Weapon _selectedWeapon, _showedWeapon;
    public event EventHandler<Appearance> OnNewSkinShowed; 
    private void OnEnable()
    {
        _appearanceShop.OnSkinPurchased += OnSkinPurchased;
    }

    private void Start()
    {
        SelectSkin(_appearanceShop.PurchasedHeads[0]);
        SelectSkin(_appearanceShop.PurchasedBodies[0]);
        SelectSkin(_appearanceShop.PurchasedWeapons[0]);
    }

    private void OnDisable()
    {
        _appearanceShop.OnSkinPurchased -= OnSkinPurchased;
    }
    public void SelectSkin(Appearance appearance)
    {
        
        switch (appearance)
        {
            case Head head : 
                if (_appearanceShop.PurchasedHeads.Contains(head))
                {
                    if(_selectedHead != null) _selectedHead.UnselectAppearance();
                    _selectedHead = head;
                    _selectedHead.SelectAppearance();
                }
                break;
            case Body body :
                if (_appearanceShop.PurchasedBodies.Contains(body))
                {
                    if(_selectedBody != null) _selectedBody.UnselectAppearance();
                    _selectedBody = body;
                    _selectedBody.SelectAppearance();
                }
                break;
            case Weapon weapon :
                if (_appearanceShop.PurchasedWeapons.Contains(weapon))
                {
                    if(_selectedWeapon != null) _selectedWeapon.UnselectAppearance();
                    _selectedWeapon = weapon;
                    _selectedWeapon.SelectAppearance();
                }
                break;
        }
        ShowSkin(appearance);
    }
    public void ShowSelectedSkin(BodyParts bodyPart)
    {
        switch (bodyPart)
        {
            case BodyParts.Head :
                ShowSkin(_selectedHead);
                break;
            case BodyParts.Body:
                ShowSkin(_selectedBody);
                break;
            case BodyParts.Weapon:
                ShowSkin(_selectedWeapon);
                break;
        }
    }
    public void ShowSkin(Appearance Skin)
    {
        Appearance showedSkin;
        
        switch (Skin)
        {
            case Head head : 
                if(_showedHead != null) _showedHead.HideAppearance();
                showedSkin = _showedHead = head;
                _showedHead.ShowAppearanceOnScene();
                break;
            case Body body : 
                if(_showedBody != null) _showedBody.HideAppearance();
                showedSkin = _showedBody = body;
                _showedBody.ShowAppearanceOnScene();
                break;
            case Weapon weapon : 
                if(_showedWeapon != null) _showedWeapon.HideAppearance();
                showedSkin = _showedWeapon = weapon;
                _showedWeapon.ShowAppearanceOnScene();
                break;
            default:
                showedSkin = _showedHead;
                break;
        }
        
        OnNewSkinShowed?.Invoke(this, showedSkin);
    }

    private void OnSkinPurchased(object sender, Appearance ctx) => SelectSkin(ctx);
    public Appearance GetSelectedSkin(BodyParts bodyPart)
    {
        return bodyPart switch
        {
            BodyParts.Body => _selectedBody,
            BodyParts.Head => _selectedHead,
            BodyParts.Weapon => _selectedWeapon,
            _ => null,
        };
    }
}
