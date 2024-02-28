using System;
using System.Linq;
using Infrastructure.Data;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Sources.ScriptableObjects;
using UnityEngine;
using ItemData = Sources.Data.ItemData;

namespace Sources.Shop
{
    public class ItemShopDisplay : MonoBehaviour, IDataReader
    {
        [SerializeField] private CharacterConfig _playerConfig;
        [SerializeField] private SkinStaticData[] _skins, _purchasedSkins;
        public event Action<ItemData> OnItemPurchased, OnNewItemPreviewed;

        private Shop _skinShopInstance;

        public void Load(PlayerProgress progress)
        {
            _skins = Resources.LoadAll<SkinStaticData>(AssetsPaths.AvailableSkins);
            string[] purchasedSkinsData = progress.PurchasedSkins;
            
            _purchasedSkins = _skins.Where(data => purchasedSkinsData.Contains(data.Name)).ToArray();
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
            OnNewItemPreviewed?.Invoke(_skinShopInstance.PreviewedItem);

        public Shop SkinShopInstance =>
            _skinShopInstance;

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
    }
}