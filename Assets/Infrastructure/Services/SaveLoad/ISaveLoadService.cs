using Infrastructure.Data;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}