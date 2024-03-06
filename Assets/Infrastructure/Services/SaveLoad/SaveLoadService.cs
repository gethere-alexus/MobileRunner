using System.IO;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressDataKey = "ProgressData";
        private const string SaveName = "Save.json";

        public void SaveProgress(PlayerProgress progressToSave)
        {
            string jsonSave = JsonUtility.ToJson(progressToSave);
            string savePath = Path.Combine(Application.persistentDataPath, SaveName);
            
            File.WriteAllText(savePath,jsonSave);
        }

        public PlayerProgress LoadProgress() =>
             PlayerPrefs.GetString(ProgressDataKey)?.ToDeserialized<PlayerProgress>();
    }
}