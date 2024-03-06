using Infrastructure.Services.AssetManagement;
using Sources.StaticData;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public SkinStaticData[] Skins { get; }
        public StatisticDescription[] StatisticDescriptions { get; }

        public StaticDataProvider(IAssetProvider assetProvider)
        {
            Skins = assetProvider.LoadAll<SkinStaticData>(AssetsPaths.AvailableSkins);
            StatisticDescriptions = assetProvider.LoadAll<StatisticDescription>(AssetsPaths.StatDescriptions);
        }
        
    }
}