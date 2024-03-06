using Infrastructure.Services.ServiceLocating;
using Sources.StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataProvider : IService
    {
        SkinStaticData[] Skins { get; }
        StatisticDescription[] StatisticDescriptions { get; }
    }
}