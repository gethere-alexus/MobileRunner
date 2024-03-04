using System;
using Infrastructure.Data;
using Sources.Shop;
using Sources.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    public class SkinShopRepresenter : MonoBehaviour, IShopRepresenter
    {
        [SerializeField] private Button _nextBtn, _previousBtn;
        public Transform PreviewSpace { get; set; }
 
        private SkinShop _skinSkinShopInstance;
        public event Action ShopInitialized;

        public void InitShop(SkinStaticData[] skins, PlayerProgress initialProgress)
        {
            RemoveInterfaceButtons();
            _skinSkinShopInstance = new SkinShop(skins, initialProgress);
            ShopInitialized?.Invoke();
            _skinSkinShopInstance.ShowItemByIndex(0);
            AssignInterfaceButtons();
        }

        private void OnEnable()
        {
            if (_skinSkinShopInstance != null)
            {
                AssignInterfaceButtons();
            }
        }

        private void OnDisable()
        {
            RemoveInterfaceButtons();
        }

        private void RemoveInterfaceButtons()
        {
            if (_skinSkinShopInstance != null)
            {
                _nextBtn.onClick.RemoveListener(_skinSkinShopInstance.ShowNextItem);
                _previousBtn.onClick.RemoveListener(_skinSkinShopInstance.ShowPreviousItem);
            }
        }

        private void AssignInterfaceButtons()
        {
            _nextBtn.onClick.AddListener(_skinSkinShopInstance.ShowNextItem);
            _previousBtn.onClick.AddListener(_skinSkinShopInstance.ShowPreviousItem);
        }

        public SkinShop SkinSkinShopInstance =>
            _skinSkinShopInstance;
    }
}