using Infrastructure.Data;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.DataProvider
{
    public interface IProgressProvider : IService
    {
        PlayerProgress PlayerProgressData { get; set; }
    }  
}