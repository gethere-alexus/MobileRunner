using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        public void SaveProgress()
        {
            
        }

        public PlayerProgress LoadProgress() =>
             PlayerPrefs.GetString("ProgressData")?.ToDeserialized<PlayerProgress>();
    }
}