using System;
using Infrastructure.Data;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.DataProvider
{
    public interface IProgressProvider : IService
    {
        PlayerProgress PlayerProgress { get; }
        void UpdateData(PlayerProgress newData);
        event Action OnDataUpdated;
    }  
}