using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string SpawnPointTag = "SpawnPoint";
        private readonly IAssetProvider _assetProvider;
        private readonly IProgressProvider _dataProvider;

        private List<IDataReader> _dataReaders { get; } = new List<IDataReader>();
        private List<IDataWriter> _dataWriters { get; } = new List<IDataWriter>();

        private Transform _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IProgressProvider dataProvider)
        {
            _assetProvider = assetProvider;
            _dataProvider = dataProvider;

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
            SkinStaticData selectedChar =
                Resources.LoadAll<SkinStaticData>(AssetsPaths.AvailableSkins)
                    .First(data => data.Name == _dataProvider.PlayerProgress.SelectedSkin);

            Transform initPoint = GameObject.FindWithTag(SpawnPointTag).transform;
            var instanceChar = Object.Instantiate(selectedChar.ItemPrefab, initPoint);
        }

        public void CreateShopWindow()
        {
            CreateUIRoot();
            var instance = _assetProvider.Instantiate(AssetsPaths.UIShop);
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
                reader.Load(_dataProvider.PlayerProgress);

                if (reader is IDataWriter writer)
                    _dataWriters.Add(writer);
            }
        }

        private void OnDataUpdated()
        {
            foreach (IDataReader reader in _dataReaders)
            {
                reader.Load(_dataProvider.PlayerProgress);
            }
        }
    }
}