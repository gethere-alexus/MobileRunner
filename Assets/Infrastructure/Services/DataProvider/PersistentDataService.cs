using System;
using Infrastructure.Data;

namespace Infrastructure.Services.DataProvider
{
    public class PersistentDataService : IProgressProvider
    {
        private PlayerProgress _progress;
        public event Action OnDataUpdated;

        public PlayerProgress GetProgress() => 
            _progress;

        public void UpdateData(PlayerProgress newData)
        {
            _progress = newData;
            OnDataUpdated?.Invoke();
        }
    }
}