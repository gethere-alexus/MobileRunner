using System.Diagnostics;
using System.IO;
using Infrastructure.Services.SaveLoad;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Sources.Utils.EditorExtensions
{
    public static class ProgressCleaner
    {
        [MenuItem("Extensions/ProgressCleaner/CleanProgress")]public static void CleanProgress()
        {
            string progressPath = Path.Combine(Application.persistentDataPath, SaveLoadService.SaveName);
            
            if(File.Exists(progressPath))
                File.Delete(progressPath);
            
            Debug.Log("Progress data were deleted");
        }
        [MenuItem("Extensions/ProgressCleaner/ShowProgress")]public static void OpenSave()
        {
            string progressPath = Application.persistentDataPath;
            Process.Start("explorer.exe", progressPath.Replace("/", "\\"));
        }
    }
}