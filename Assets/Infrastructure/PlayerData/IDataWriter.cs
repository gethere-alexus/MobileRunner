namespace Infrastructure.PlayerData
{
    public interface IDataWriter : IDataReader
    {
        void Update(PlayerProgress progress);
    }
}