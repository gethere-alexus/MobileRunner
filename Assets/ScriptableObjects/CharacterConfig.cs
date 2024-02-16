using System.Linq;
using ScriptableObjects;
using Sources.Player;
using UnityEngine;

namespace Sources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private ItemDataContainer _skin;
        [SerializeField] private Statistic[] _characterStats;

        private void OnValidate()
        {
            ValidateLastStatistic();
        }

        private void ValidateLastStatistic()
        {
            int validatingStatIndex = _characterStats.Length - 1;
            Statistic validatingStat = _characterStats[validatingStatIndex];

            bool isStatValidated = true;
            for (int i = 0; i < _characterStats.Length; i++)
            {
                if (_characterStats[i].AplicableBoost == validatingStat.AplicableBoost && i != validatingStatIndex)
                {
                    isStatValidated = false;
                }
            }

            if (!isStatValidated)
            {
                _characterStats[validatingStatIndex].AplicableBoost = null;
            }
        }

        public void SelectSkin(ItemDataContainer skinDataContainer) =>
            _skin = skinDataContainer;

        public Statistic GetStatInformation(StatisticDescription searchingStat) =>
            _characterStats.First(statistic => statistic.AplicableBoost == searchingStat);

        public ItemDataContainer UsingSkin =>
            _skin;
    }
}