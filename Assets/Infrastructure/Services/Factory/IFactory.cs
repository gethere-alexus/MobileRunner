using System.Collections.Generic;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.Factory
{
    public interface IFactory : IService
    {
        public void CreateMainMenu();
        List<IDataWriter> DataWriters { get; }
        List<IDataReader> DataObservers { get; }
        void CleanUp();
    }
}