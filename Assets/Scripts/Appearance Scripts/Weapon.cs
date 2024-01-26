using UnityEngine;

public class Weapon : Appearance
{
   [SerializeField] private string _weaponHandlingAnimation;
   

   public string WeaponHandlingAnimation => _weaponHandlingAnimation;
}
