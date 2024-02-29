using System.Collections.Generic;
using Sources.Data;
using Sources.Shop.ShopButton;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Shop
{
    public class ShopButtonDisplay : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _charactersShopDisplay;
        [SerializeField] private Button _purchaseButton, _selectButton, _selectedButton;
        [SerializeField] private Button _previousItemButton, _nextItemButton;

        private Dictionary<ItemStatus, Button> _statusButtons;
        private Button buttonInstance;

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
            _purchaseButton.onClick.AddListener(_charactersShopDisplay.SkinShopInstance.PurchaseShowedSkin);
            _selectButton.onClick.AddListener(_charactersShopDisplay.SkinShopInstance.SelectShowedItem);
            
            _previousItemButton.onClick.AddListener(_charactersShopDisplay.SkinShopInstance.ShowPreviousSkin);
            _nextItemButton.onClick.AddListener(_charactersShopDisplay.SkinShopInstance.ShowNextItem);
            
            _charactersShopDisplay.SkinShopInstance.NewItemPreviewed += DisplayButtonUI;
        }

        private void OnDisable()
        {
            _purchaseButton.onClick.RemoveListener(_charactersShopDisplay.SkinShopInstance.PurchaseShowedSkin);
            _selectButton.onClick.RemoveListener(_charactersShopDisplay.SkinShopInstance.SelectShowedItem);
            
            _previousItemButton.onClick.RemoveListener(_charactersShopDisplay.SkinShopInstance.ShowPreviousSkin);
            _nextItemButton.onClick.RemoveListener(_charactersShopDisplay.SkinShopInstance.ShowNextItem);
            
            _charactersShopDisplay.SkinShopInstance.NewItemPreviewed -= DisplayButtonUI;
        }

        private void DisplayButtonUI(ItemData data) 
        {
            if (buttonInstance != null) 
                buttonInstance.gameObject.SetActive(false);

            buttonInstance = _statusButtons[data.ItemStatus];
            
            if(buttonInstance.TryGetComponent<PurchaseButton>(out PurchaseButton buttonDisplay))
            {
                buttonDisplay.Construct(data);
            }
            
            buttonInstance.gameObject.SetActive(true);
        }
    }
}