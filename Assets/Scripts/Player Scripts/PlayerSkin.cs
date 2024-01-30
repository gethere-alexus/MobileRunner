using UnityEngine;
public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private AppearanceShop _appearanceShop;
    [SerializeField] private Skin _selectedSkin;
    
    //public event EventHandler<Appearance> OnNewSkinShowed;
    //public event EventHandler<PlayerAppearance> OnDataUpdated;
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
    public void SelectSkin(Skin skinToSelect)
    {
    }
    public void ShowSelectedSkin(BodyParts bodyPart)
    {
    }
    public void ShowSkin()
    {
    }
    
}
