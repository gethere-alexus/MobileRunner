using System.Collections.Generic;
using Sources.Data;
using Sources.Shop;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    public class ShopButtonDisplay : MonoBehaviour
    {
        [FormerlySerializedAs("_charactersShopDisplay")] [FormerlySerializedAs("_charactersShopPresenterDisplay")] [SerializeField] private SkinShopDisplay _charactersSkinShopDisplay;
        [SerializeField] private Button _purchaseButton, _selectButton, _selectedButton;
        [SerializeField] private Button _previousItemButton, _nextItemButton;

        private Dictionary<ItemStatus, Button> _statusButtons;
        //private Button buttonInstance;

        private void Awake()
        {
            _statusButtons = new Dictionary<ItemStatus, Button>()
            {
                { ItemStatus.Purchasable, _purchaseButton },
                { ItemStatus.Selectable, _selectButton },
                { ItemStatus.Selected, _selectedButton },
            };
        }

        private void OnEnable()
        {
            _purchaseButton.onClick.AddListener(_charactersSkinShopDisplay.SkinSkinShopInstance.PurchaseShowedItem);
            _selectButton.onClick.AddListener(_charactersSkinShopDisplay.SkinSkinShopInstance.SelectShowedItem);
            
            _previousItemButton.onClick.AddListener(_charactersSkinShopDisplay.SkinSkinShopInstance.ShowPreviousItem);
            _nextItemButton.onClick.AddListener(_charactersSkinShopDisplay.SkinSkinShopInstance.ShowNextItem);
            
            _charactersSkinShopDisplay.SkinSkinShopInstance.NewItemPreviewed += DisplayButtonUI;
        }

        private void OnDisable()
        {
            _purchaseButton.onClick.RemoveListener(_charactersSkinShopDisplay.SkinSkinShopInstance.PurchaseShowedItem);
            _selectButton.onClick.RemoveListener(_charactersSkinShopDisplay.SkinSkinShopInstance.SelectShowedItem);
            
            _previousItemButton.onClick.RemoveListener(_charactersSkinShopDisplay.SkinSkinShopInstance.ShowPreviousItem);
            _nextItemButton.onClick.RemoveListener(_charactersSkinShopDisplay.SkinSkinShopInstance.ShowNextItem);
            
            _charactersSkinShopDisplay.SkinSkinShopInstance.NewItemPreviewed -= DisplayButtonUI;
        }

        private void DisplayButtonUI(ItemData data) 
        {
            // if (buttonInstance != null) 
            //     buttonInstance.gameObject.SetActive(false);
            //
            // buttonInstance = _statusButtons[data.ItemStatus];
            //
            // // if(buttonInstance.TryGetComponent<PurchaseButton>(out PurchaseButton buttonDisplay))
            // // {
            // //     buttonDisplay.Construct(data);
            // // }
            //
            // buttonInstance.gameObject.SetActive(true);
        }
    }
}