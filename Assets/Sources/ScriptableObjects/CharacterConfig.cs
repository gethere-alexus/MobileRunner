using System.Linq;
using Sources.Player;
using UnityEngine;

namespace Sources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private ItemData _skin;
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

        public void SelectSkin(ItemData skin)
        {
            if (_skin != null)
            {
                foreach (var statBoost in _skin.AppliedBoosts)
                {   
                    GetStatInformation(statBoost.BoostData).DecrementBoostingValue(statBoost.BoostValue);
                }
            }
            
            _skin = skin;

            foreach (var statBoost in _skin.AppliedBoosts)
            {
                GetStatInformation(statBoost.BoostData).IncrementBoostingValue(statBoost.BoostValue);
            }
        }

        public Statistic GetStatInformation(StatisticDescription searchingStat) =>
            _characterStats.First(statistic => statistic.AplicableBoost == searchingStat);

        public ItemData UsingSkin =>
            _skin;
    }
}