using Infrastructure.Data;

namespace Infrastructure.Services.DataProvider
{
    public interface IDataWriter : IDataReader
    {
        void Update(PlayerProgress progress);
    }
}