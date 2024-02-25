using Infrastructure.Data;

namespace Infrastructure.Services.DataProvider
{
    public interface IDataReader
    {
        void Load(PlayerProgress progress);
    }
}