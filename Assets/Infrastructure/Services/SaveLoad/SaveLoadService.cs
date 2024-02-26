using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressDataKey = "ProgressData";
        
        private readonly IUIFactory _gameIuiFactory;
        private readonly IProgressProvider _progressProvider;

        public SaveLoadService(IProgressProvider progressProvider,IUIFactory gameIuiFactory)
        {
            _progressProvider = progressProvider;
            _gameIuiFactory = gameIuiFactory;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressDataKey, _progressProvider.PlayerProgressData.ToJson());
        }

        public PlayerProgress LoadProgress() =>
             PlayerPrefs.GetString(ProgressDataKey)?.ToDeserialized<PlayerProgress>();
    }
}