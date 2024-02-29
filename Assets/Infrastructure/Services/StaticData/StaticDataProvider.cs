using Infrastructure.Services.AssetManagement;
using Sources.ScriptableObjects;

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