using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.InputService;
using Infrastructure.Services.StaticData;
using Sources.Input;
using Sources.ScriptableObjects;
using Sources.Shop;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string SpawnPointTag = "SpawnPoint";
        
        private readonly IAssetProvider _assetProvider;
        private readonly IProgressProvider _dataProvider;
        private readonly IStaticDataProvider _staticDataProvider;

        private List<IDataReader> _dataReaders { get; } = new List<IDataReader>();
        private List<IDataWriter> _dataWriters { get; } = new List<IDataWriter>();

        private Transform _uiRoot;
        private IInputProcessingService _inputService;

        public UIFactory(IAssetProvider assetProvider, IProgressProvider dataProvider, IStaticDataProvider staticDataProvider, IInputProcessingService inputService)
        {
            _assetProvider = assetProvider;
            _dataProvider = dataProvider;
            _staticDataProvider = staticDataProvider;
            _inputService = inputService;

            dataProvider.OnDataUpdated += OnDataUpdated;
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
            CreateCharacterPreview();
        }

        private void CreateUIMenu(out GameObject instanceUI)
        {
            instanceUI = _assetProvider.Instantiate(AssetsPaths.UIMainMenu);
            instanceUI.transform.SetParent(_uiRoot);
            RegisterObservers(instanceUI);
        }

        public void CreateCharacterPreview()
        {
            SkinStaticData selectedChar = _staticDataProvider.Skins
                    .First(data => data.Name == _dataProvider.GetProgress().SelectedSkin);

            Transform initPoint = GameObject.FindWithTag(SpawnPointTag).transform;
            
            var instanceChar = Object.Instantiate(selectedChar.ItemPrefab, initPoint);
            instanceChar.AddComponent<PlayerOverviewRotation>().Construct(_inputService, 
                instanceChar.GetComponent<Rigidbody>());
        }

        public void CreateShopWindow()
        {
            CreateUIRoot();
            var instance = _assetProvider.Instantiate(AssetsPaths.UIShop);
            
            foreach (IShopPresenter shop in instance.GetComponentsInChildren<IShopPresenter>(true))
            {
                shop.PreviewSpace = _assetProvider.Instantiate(AssetsPaths.PreviewSpace).transform;
                shop.InitShop(_staticDataProvider.Skins);
            }
            
            instance.transform.SetParent(_uiRoot);
            RegisterObservers(instance);
        }

        public void ClearObservers()
        {
            _dataReaders.Clear();
            _dataWriters.Clear();
        }

        private void RegisterObservers(GameObject obj)
        {
            foreach (var reader in obj.GetComponentsInChildren<IDataReader>())
            {
                _dataReaders.Add(reader);
                reader.LoadData(_dataProvider.GetProgress());

                if (reader is IDataWriter writer)
                    _dataWriters.Add(writer);
            }
        }

        private void OnDataUpdated()
        {
            foreach (IDataReader reader in _dataReaders)
            {
                reader.LoadData(_dataProvider.GetProgress());
            }
        }
    }
}