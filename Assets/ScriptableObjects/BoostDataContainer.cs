using UnityEngine;

public enum BoostType {HealthBoost, DamageBoost, CriticalDamageBoost, LuckBoost,FireRateBoost}

[CreateAssetMenu(fileName = "Boost")]
public class BoostDataContainer : ScriptableObject
{
   [SerializeField] private BoostType _boost;
   [SerializeField] private Sprite _boostSprite;

   public BoostType Boost => _boost;
   public Sprite BoostSprite => _boostSprite;
}
