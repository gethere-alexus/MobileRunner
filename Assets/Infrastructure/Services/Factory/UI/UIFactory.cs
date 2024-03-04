using System.Collections.Generic;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory.Character;
using Infrastructure.Services.StaticData;
using Sources.Shop;
using UnityEngine;

namespace Infrastructure.Services.Factory.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ICharacterFactory _characterFactory;

        private List<IDataReader> _dataReaders { get; } = new List<IDataReader>();
        private List<IDataWriter> _dataWriters { get; } = new List<IDataWriter>();

        private Transform _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IProgressProvider progressProvider, IStaticDataProvider staticDataProvider, ICharacterFactory charFactory)
        {
            _assetProvider = assetProvider;
            _progressProvider = progressProvider;
            _staticDataProvider = staticDataProvider;
            _characterFactory = charFactory;

            progressProvider.OnDataUpdated += OnDataUpdated;
        }

        public void CreateUIRoot()
        {
            if (_uiRoot == null)
            {
                _uiRoot = _assetProvider.Instantiate(AssetsPaths.UIRoot).transform;
            }
        }

        public void CreateMainMenu()
        {
            CreateUIRoot();

            CreateUIMenu(out var instanceUI);
            _characterFactory.CreateCharacterPreview();
        }

        private void CreateUIMenu(out GameObject instanceUI)
        {
            instanceUI = _assetProvider.Instantiate(AssetsPaths.UIMainMenu);
            instanceUI.transform.SetParent(_uiRoot);
            RegisterObserver(instanceUI.GetComponentsInChildren<IDataReader>());
        }

        public void CreateShopWindow()
        {
            CreateUIRoot();
            var instance = _assetProvider.Instantiate(AssetsPaths.UIShop);
            
            Transform previewSpace = _assetProvider.Instantiate(AssetsPaths.PreviewSpace).transform;
            previewSpace.SetParent(instance.transform);
            
            foreach (IShopRepresenter shop in instance.GetComponentsInChildren<IShopRepresenter>(true))
            {
                shop.PreviewSpace = previewSpace;
                shop.InitShop(_staticDataProvider.Skins, _progressProvider.GetProgress());
                RegisterObserver(shop.SkinSkinShopInstance);
            }
            
            instance.transform.SetParent(_uiRoot);
        }

        public void ClearObservers()
        {
            _dataReaders.Clear();
            _dataWriters.Clear();
        }

        private void RegisterObserver(IDataReader reader)
        {
            _dataReaders.Add(reader);
            reader.LoadData(_progressProvider.GetProgress());

            if (reader is IDataWriter writer)
                _dataWriters.Add(writer);
        }

        private void RegisterObserver(IDataReader[] readers)
        {
            foreach (var reader in readers)
            {
                RegisterObserver(reader);
            }
        }

        private void OnDataUpdated()
        {
            foreach (IDataReader reader in _dataReaders)
            {
                reader.LoadData(_progressProvider.GetProgress());
            }
        }
    }
}