using System.IO;
using Infrastructure.Data;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        public const string SaveName = "GameProgress.json";
        private readonly string _savePath;

        public SaveLoadService()
        {
            _savePath = Path.Combine(Application.persistentDataPath, SaveName);
        }

        public void SaveProgress(PlayerProgress progressToSave)
        {
            string jsonSave = JsonUtility.ToJson(progressToSave);
            
            File.WriteAllText(_savePath,jsonSave);
        }

        public PlayerProgress LoadProgress()
        {
            PlayerProgress toReturn = null;
            if (File.Exists(_savePath))
            {
                string json = File.ReadAllText(_savePath);
                toReturn = JsonUtility.FromJson<PlayerProgress>(json);
                Debug.Log("File read");
            }

            return toReturn;
        }
    }
}