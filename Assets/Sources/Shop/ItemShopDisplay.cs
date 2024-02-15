using System;
using ScriptableObjects;
using Sources.Data;
using Sources.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Sources.Shop
{
    public class ItemShopDisplay : MonoBehaviour
    {
        [SerializeField] private SkinDataContainer[] _skins, _purchasedSkins;
        public event EventHandler<ItemData> OnItemPurchased, OnNewItemPreviewed;

        private Shop _skinShopInstance;

        [Inject]
        public void Construct(CharacterConfig playerConfig)
        {
            _skinShopInstance = new Shop(playerConfig, _skins, _purchasedSkins);
        }

        private void Start()
        {
            DisplaySkinByIndex(0);
        }

        public void DisplayNextSkin()
        {
            _skinShopInstance.PreviewItemSkin();
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

        private void UpdateUIView()
        {
            OnNewItemPreviewed?.Invoke(this, _skinShopInstance.PreviewedItem);
        }

        public Shop SkinShopInstance => _skinShopInstance;
    }
}