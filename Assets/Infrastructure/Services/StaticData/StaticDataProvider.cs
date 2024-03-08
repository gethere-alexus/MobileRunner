using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.AssetManagement;
using Sources.StaticData;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public SkinStaticData[] Skins { get; }
        public GunStaticData[] Guns { get; }

        public StaticDataProvider(IAssetProvider assetProvider)
        {
            Skins = assetProvider.LoadAll<SkinStaticData>(AssetsPaths.AvailableSkins);
            Guns = assetProvider.LoadAll<GunStaticData>(AssetsPaths.AvailableGuns);
        }
        
    }
}