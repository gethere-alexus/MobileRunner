using System.Collections.Generic;
using Sources.Data;
using Sources.Shop;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    [RequireComponent(typeof(SkinShopRepresenter))]
    public class ShopButtons : MonoBehaviour
    {
        [FormerlySerializedAs("_skinShopDisplay")] [SerializeField] private SkinShopRepresenter _skinShopRepresenter;
        [SerializeField] private Button _previousItemButton, _nextItemButton;

        private Dictionary<ItemStatus, Button> _statusButtons;

        //private Button buttonInstance
        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _skinShopRepresenter.ShopInitialized += SubscribeSkinShopEvents;
        }

        private void SubscribeSkinShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _previousItemButton.onClick.AddListener(_skinShopRepresenter.SkinSkinShopInstance.ShowPreviousItem);
                _nextItemButton.onClick.AddListener(_skinShopRepresenter.SkinSkinShopInstance.ShowNextItem);

                _skinShopRepresenter.SkinSkinShopInstance.NewItemPreviewed += DisplayButtonUI;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _previousItemButton.onClick.RemoveListener(_skinShopRepresenter.SkinSkinShopInstance
                    .ShowPreviousItem);
                _nextItemButton.onClick.RemoveListener(_skinShopRepresenter.SkinSkinShopInstance.ShowNextItem);

                _skinShopRepresenter.SkinSkinShopInstance.NewItemPreviewed -= DisplayButtonUI;
            }
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