using System;
using Appearance_Scripts;
using UnityEngine;
public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    
    private Skin[] _skins;
    private Skin _showedSkin, _selectedSkin;
    private int _observingSkinIndex = 0;

    public event EventHandler<Skin> OnNewSkinShowed; 
    private void Awake()
    {
        _skins = _shop.AvailableToPurchaseSkins;
        ShowSkinByIndex(_observingSkinIndex);
    }

    public void ShowSkinByIndex(int index)
    {
        _observingSkinIndex = index > _skins.Length || index < 0 ? 0 : index;
        
        _showedSkin = _skins[_observingSkinIndex];
        
        OnNewSkinShowed?.Invoke(this, _showedSkin);
    }
    public void ShowNextSkin()
    {
        _observingSkinIndex = _observingSkinIndex + 1 >= _skins.Length ? 0 : _observingSkinIndex + 1;
        ShowSkinByIndex(_observingSkinIndex);
    }
    public void ShowPreviousSkin()
    {
        _observingSkinIndex = _observingSkinIndex - 1 < 0 ? _skins.Length - 1 : _observingSkinIndex - 1;
        ShowSkinByIndex(_observingSkinIndex);
    }
}
