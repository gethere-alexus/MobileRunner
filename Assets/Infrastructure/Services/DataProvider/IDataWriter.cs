using Infrastructure.Data;

namespace Infrastructure.Services.DataProvider
{
    public interface IDataWriter : IDataReader
    {
        void UpdateData();
    }
}