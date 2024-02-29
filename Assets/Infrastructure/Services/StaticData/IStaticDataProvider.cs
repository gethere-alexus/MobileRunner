using Infrastructure.Services.ServiceLocating;
using Sources.ScriptableObjects;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataProvider : IService
    {
        SkinStaticData[] Skins { get; }
    }
}