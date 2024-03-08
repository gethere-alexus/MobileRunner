using System.Collections.Generic;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory.Character;
using Infrastructure.Services.StaticData;
using Sources.Money;
using Sources.Shop.ShopRepresenters;
using Sources.StaticData;
using Sources.UI.Elements.Panels;
using UnityEngine;

namespace Infrastructure.Services.Factory.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ICharacterFactory _characterFactory;

        private List<IDataReader>_dataReaders { get; } = new List<IDataReader>();
        private List<IDataWriter> _dataWriters { get; } = new List<IDataWriter>();

        private IWallet _walletInstance;

        private Transform _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IProgressProvider progressProvider, IStaticDataProvider staticDataProvider, ICharacterFactory charFactory)
        {
            _assetProvider = assetProvider;
            _progressProvider = progressProvider;
            _staticDataProvider = staticDataProvider;
            _characterFactory = charFactory;

            progressProvider.DataUpdated += DataUpdated;
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

            // building menu
            GameObject instanceUI = _assetProvider.Instantiate(AssetsPaths.UIMainMenu);
            instanceUI.transform.SetParent(_uiRoot);
            RegisterObserver(instanceUI.GetComponentsInChildren<IDataReader>());

            _walletInstance = instanceUI.GetComponentInChildren<WalletView>().WalletInstance;
            
            _progressProvider.DataUpdated += _characterFactory.CreateCharacterPreview;
            _characterFactory.CreateCharacterPreview();
        }

        public void CreateShopWindow()
        {
            CreateUIRoot();
            var shopInstance = _assetProvider.Instantiate(AssetsPaths.UIShop);
            
            Transform previewSpace = _assetProvider.Instantiate(AssetsPaths.PreviewSpace).transform;
            previewSpace.SetParent(shopInstance.transform);
            
            foreach (IDataReader dataReader in shopInstance.GetComponentsInChildren<IDataReader>(true))
            {
                RegisterObserver(dataReader);
            }
            
            InstantiateShop(shopInstance, _staticDataProvider.Skins, previewSpace);
            InstantiateShop(shopInstance, _staticDataProvider.Guns, previewSpace);

            shopInstance.transform.SetParent(_uiRoot);
        }

        private void InstantiateShop<TItem>(GameObject shopInstance, TItem[] items, Transform previewStorage)
            where TItem : ItemStaticData
        {
            IShopRepresenter<TItem> shopRepresenter = shopInstance.GetComponentInChildren<IShopRepresenter<TItem>>(true);
            
            shopRepresenter.PreviewSpace = previewStorage;
            shopRepresenter.InitShop(items, _progressProvider.GetProgress(), _walletInstance);
            
            RegisterObserver(shopRepresenter.ShopInstance);
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

        private void DataUpdated()
        {
            foreach (IDataReader reader in _dataReaders)
            {
                reader.LoadData(_progressProvider.GetProgress());
            }
        }
    }
}