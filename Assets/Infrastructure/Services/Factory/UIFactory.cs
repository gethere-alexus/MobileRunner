using Infrastructure.Services.AssetManagement;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private Transform _uiRoot;
        public UIFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void CreateUIRoot()
        {
            if (_uiRoot == null)
            {
                _uiRoot = _assetProvider.Instantiate(AssetsPaths.UIRoot).transform;
            }
        }

        public void CreateUIMenu()
        {
            CreateUIRoot();
            
            _assetProvider.Instantiate(AssetsPaths.UIMainMenu)
                .transform.SetParent(_uiRoot);
        }

        public void CreateShopWindow()
        {
            CreateUIRoot();
            _assetProvider.Instantiate(AssetsPaths.UIShop);
        }
    }
}