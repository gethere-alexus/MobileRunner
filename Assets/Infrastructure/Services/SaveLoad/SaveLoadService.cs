using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressDataKey = "ProgressData";
        
        private readonly IUIFactory _uiFactory;
        private readonly IProgressProvider _progressProvider;

        public SaveLoadService(IProgressProvider progressProvider,IUIFactory uiFactory)
        {
            _progressProvider = progressProvider;
            _uiFactory = uiFactory;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressDataKey, _progressProvider.PlayerProgress.ToJson());
        }

        public PlayerProgress LoadProgress() =>
             PlayerPrefs.GetString(ProgressDataKey)?.ToDeserialized<PlayerProgress>();
    }
}