using Infrastructure.AssetManagement;

namespace Infrastructure.Factory
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