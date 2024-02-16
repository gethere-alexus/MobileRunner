using ScriptableObjects;
using UnityEngine;

namespace Sources.Boost
{
    [System.Serializable]
    public class Boost
    {
        [SerializeField] private StatisticDescription _boostData;
        [SerializeField] private int _boostValue;

        public StatisticDescription BoostData => _boostData;

        public int BoostValue => _boostValue;
    }
}