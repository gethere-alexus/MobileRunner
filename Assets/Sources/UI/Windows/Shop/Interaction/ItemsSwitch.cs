using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction
{
    public class ItemsSwitch : MonoBehaviour
    {
        [SerializeField] private SkinShopRepresenter _shopRepresenter;
        [SerializeField] private Button _nextItemButton, _previousItemButton;


        private void OnEnable()
        {
            _shopRepresenter.ShopInitialized += AssignControlButtons;
            if (_shopRepresenter.SkinSkinShopInstance != null)
            {
                AssignControlButtons();
            }
        }

        private void OnDisable()
        {
            _shopRepresenter.ShopInitialized -= AssignControlButtons;
            if (_shopRepresenter.SkinSkinShopInstance != null)
            {
                _nextItemButton.onClick.RemoveAllListeners();
                _previousItemButton.onClick.RemoveAllListeners();
            }
        }

        private void AssignControlButtons()
        {
            _nextItemButton.onClick.AddListener(_shopRepresenter.SkinSkinShopInstance.ShowNextItem);
            _previousItemButton.onClick.AddListener(_shopRepresenter.SkinSkinShopInstance.ShowPreviousItem);
        }
    }
}