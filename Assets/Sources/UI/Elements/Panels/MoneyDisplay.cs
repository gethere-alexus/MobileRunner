using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Sources.Utils;
using TMPro;
using UnityEngine;

namespace Sources.UI.Elements.Panels
{
    public class MoneyDisplay : MonoBehaviour, IDataReader
    {
        [SerializeField] private TMP_Text _moneyText;
        public void Load(PlayerProgress progress)
        {
            _moneyText.text = TextFormatter.DivideIntWithChar(progress.Money, ',');
        }
    }
}
