using System;
using ScriptableObjects;
using Sources.Data;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Sources.Shop
{
    public class ItemShopDisplay : MonoBehaviour
    {
        [SerializeField] private SkinDataContainer[] _skins, _purchasedSkins;
        [SerializeField] private CharacterConfig _playerConfig;
        public event EventHandler<ItemData> OnItemPurchased, OnNewItemPreviewed;

        private Shop _skinShopInstance;

        private void Awake()
        {
            _skinShopInstance = new Shop(_playerConfig, _skins, _purchasedSkins);
        }

        private void OnEnable()
        {
            DisplaySelectedSkin();
        }

        private void Start()
        {
            DisplaySkinByIndex(0);
        }

        public void DisplayNextSkin()
        {
            _skinShopInstance.PreviewNextItem();
            UpdateUIView();
        }

        public void DisplaySelectedSkin()
        {
            _skinShopInstance.PreviewSelectedSkin();
            UpdateUIView();
        }

        public void DisplayPreviousSkin()
        {
            _skinShopInstance.PreviewPreviousSkin();
            UpdateUIView();
        }

        public void DisplaySkinByIndex(int index)
        {
            _skinShopInstance.PreviewItemByIndex(index);
            UpdateUIView();
        }

        public void PurchasePreviewedSkin()
        {
            _skinShopInstance.PurchaseShowedSkin();
            UpdateUIView();
        }

        public void SelectPreviewedSkin()
        {
            _skinShopInstance.SelectShowedItem();
            UpdateUIView();
        }

        private void UpdateUIView() =>
            OnNewItemPreviewed?.Invoke(this, _skinShopInstance.PreviewedItem);

        public Shop SkinShopInstance =>
            _skinShopInstance;
    }
}