using System.Collections.Generic;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;

namespace Infrastructure.Services.Factory
{
    public class GameFactory : IFactory
    {
        private readonly IAssetProvider _assetProvider;
        
        public List<IDataWriter> DataWriters { get; } = new List<IDataWriter>();
        public List<IDataReader> DataObservers { get; } = new List<IDataReader>();
        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateMainMenu()
        {
            _assetProvider.Instantiate(AssetsPaths.MainMenuCanvas);
        }

        public void CleanUp()
        {
            DataWriters.Clear();
            DataObservers.Clear();
        }
    }
}