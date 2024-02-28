using System;
using Infrastructure.Data;

namespace Infrastructure.Services.DataProvider
{
    public class PersistentDataService : IProgressProvider
    {
        private PlayerProgress _playerProgress;

        public event Action OnDataUpdated;

        public PersistentDataService()
        {
            _playerProgress = new PlayerProgress();
        } 

        public void UpdateData(PlayerProgress newData)
        {
            _playerProgress = newData;
        }
        public PlayerProgress PlayerProgress => _playerProgress;
    }
}