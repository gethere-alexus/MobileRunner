namespace Infrastructure.PlayerData
{
    public interface IDataReader
    {
        void Load(PlayerProgress progress);
    }
}