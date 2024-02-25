using Infrastructure.Data;

namespace Infrastructure.Services.DataProvider
{
    public class PersistentDataService : IProgressProvider
    {
        public PlayerProgress PlayerProgressData { get; set; }

        public PersistentDataService()
        {
            PlayerProgressData = new PlayerProgress();
        }
    }
}