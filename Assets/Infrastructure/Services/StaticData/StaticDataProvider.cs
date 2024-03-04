using Infrastructure.Services.AssetManagement;
using Sources.StaticData;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public SkinStaticData[] Skins { get; }

        public StaticDataProvider(IAssetProvider assetProvider)
        {
            Skins = assetProvider.LoadAll<SkinStaticData>(AssetsPaths.AvailableSkins);
        }
    }
}