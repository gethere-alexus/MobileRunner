using UnityEngine;

namespace Sources.ScriptableObjects
{
    public enum BoostType
    {
        HealthBoost,
        DamageBoost,
        CriticalDamageBoost,
        LuckBoost,
        FireRateBoost
    }

    [CreateAssetMenu(menuName = ("DataContainers/BoostDataContainer"))]
    public class BoostDataContainer : ScriptableObject
    {
        [SerializeField] private BoostType _boost;
        [SerializeField] private Sprite _boostSprite;

        public BoostType Boost => _boost;
        public Sprite BoostSprite => _boostSprite;
    }
}