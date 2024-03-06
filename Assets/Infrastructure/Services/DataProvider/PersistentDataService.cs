using System;
using Infrastructure.Data;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.DataProvider
{
    public class PersistentDataService : IProgressProvider
    {
        private PlayerProgress _progress;
        private ISaveLoadService _saveLoadService;

        public PersistentDataService(ISaveLoadService saveLoad)
        {
            _saveLoadService = saveLoad;
        }

        public event Action OnDataUpdated;

        public PlayerProgress GetProgress() => 
            _progress;

        public void UpdateData(PlayerProgress newData)
        {
            _progress = newData;
            OnDataUpdated?.Invoke();
            _saveLoadService.SaveProgress(_progress);
        }
    }
}