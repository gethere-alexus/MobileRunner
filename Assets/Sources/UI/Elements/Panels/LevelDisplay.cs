using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Panels
{
    public class LevelDisplay : MonoBehaviour, IDataReader
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _progressText;
        [SerializeField] private Slider _progressBar;

        public void LoadData(PlayerProgress progress)
        {
            Debug.Log("Loaded");
            _levelText.text = progress.Level.ToString();
            
            _progressText.text = $"{progress.CurrentXp}/{progress.RequiredXp}";

            _progressBar.maxValue = progress.RequiredXp;
            _progressBar.value = progress.CurrentXp;
        }
    }
}
