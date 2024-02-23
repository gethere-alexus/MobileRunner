using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.PlayerData
{
    public interface IProgressProvider : IService
    {
        int Money { get; set; }
    }  
}