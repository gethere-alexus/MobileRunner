using System.Collections.Generic;
using Sources.Data;
using Sources.Shop;
using Sources.UI.ShopButtonView;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI
{
    public class UIButtonDisplay : MonoBehaviour
    {
        [SerializeField] private ItemShopDisplay _charactersShopDisplay;
        [SerializeField] private Transform _buttonStorage;
        [SerializeField] private Button _purchaseButton, _selectButton, _selectedButton;

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
            _charactersShopDisplay.OnNewItemPreviewed += DisplayButtonUI;
        }

        private void OnDisable()
        {
            _charactersShopDisplay.OnNewItemPreviewed -= DisplayButtonUI;
        }

        private void DisplayButtonUI(object sender, ItemData data) // TODO: Update UI on purchase
        {
            if (buttonInstance != null) Destroy(buttonInstance.gameObject);

            buttonInstance = Instantiate(_statusButtons[data.ItemStatus], _buttonStorage);
            if (buttonInstance.gameObject.TryGetComponent(out UIShopButtonView shopButtonView))
            {
                shopButtonView.Construct(data, _charactersShopDisplay);
            }

            buttonInstance.transform.SetSiblingIndex(_buttonStorage.childCount / 2);
        }
    }
}