using Infrastructure.Services.AssetManagement;

namespace Infrastructure.Services.Factory
{
    public class GameFactory : IFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateMainMenu()
        {
            _assetProvider.Instantiate(AssetsPaths.MainMenuCanvas);
        }
    }
}