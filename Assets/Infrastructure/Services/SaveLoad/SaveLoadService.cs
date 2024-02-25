using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressDataKey = "ProgressData";
        
        private readonly IFactory _gameFactory;
        private readonly IProgressProvider _progressProvider;

        public SaveLoadService(IProgressProvider progressProvider,IFactory gameFactory)
        {
            _progressProvider = progressProvider;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (IDataWriter dataWriter in _gameFactory.DataWriters)
                dataWriter.Update(_progressProvider.PlayerProgressData);
            
            PlayerPrefs.SetString(ProgressDataKey, _progressProvider.PlayerProgressData.ToJson());
        }

        public PlayerProgress LoadProgress() =>
             PlayerPrefs.GetString(ProgressDataKey)?.ToDeserialized<PlayerProgress>();
    }
}