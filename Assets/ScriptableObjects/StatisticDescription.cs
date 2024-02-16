using UnityEngine;

namespace ScriptableObjects
{
    public enum StatisticType
    {
        HealthBoost,
        DamageBoost,
        CriticalDamageBoost,
        LuckBoost,
        FireRateBoost
    }

    [CreateAssetMenu(menuName = ("DataContainers/StatisticDescription"))]
    public class StatisticDescription : ScriptableObject
    {
        [SerializeField] private StatisticType _statistic;
        [SerializeField] private Sprite _boostSprite;

        public StatisticType Statistic => _statistic;
        public Sprite BoostSprite => _boostSprite;
    }
}