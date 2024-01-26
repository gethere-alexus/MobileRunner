using UnityEngine;

[System.Serializable]
public class Boost
{
   [SerializeField] private BoostDataContainer _boostData;
   [SerializeField] private int _boostValue;

   public BoostDataContainer BoostData => _boostData;

   public int BoostValue => _boostValue;
}
