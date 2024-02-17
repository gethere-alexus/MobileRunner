using System.Collections.Generic;
using Sources.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Shop
{
    public class ShopButtonDisplay : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _charactersShopDisplay;
        [SerializeField] private Button _purchaseButton, _selectButton, _selectedButton;
        [SerializeField] private Button _displayNextItemButton, _displayPreviousItemButton;

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
            _purchaseButton.onClick.AddListener(_charactersShopDisplay.PurchasePreviewedSkin);
            _selectButton.onClick.AddListener(_charactersShopDisplay.SelectPreviewedSkin);

            _displayNextItemButton.onClick.AddListener(_charactersShopDisplay.DisplayNextSkin);
            _displayPreviousItemButton.onClick.AddListener(_charactersShopDisplay.DisplayPreviousSkin);

            _charactersShopDisplay.OnNewItemPreviewed += DisplayButtonUI;
        }

        private void OnDisable()
        {
            _charactersShopDisplay.OnNewItemPreviewed -= DisplayButtonUI;
        }

        private void DisplayButtonUI(object sender, ItemData data) // TODO: Update UI on purchase
        {
            if (buttonInstance != null)
                buttonInstance.gameObject.SetActive(false);

            buttonInstance = _statusButtons[data.ItemStatus];

            buttonInstance.gameObject.SetActive(true);
        }
    }
}