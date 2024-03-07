using System;
using Infrastructure.Data;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.DataProvider
{
    public interface IProgressProvider : IService
    {
        void UpdateData(PlayerProgress newData);
        PlayerProgress GetProgress();
        event Action DataUpdated;
    }  
}