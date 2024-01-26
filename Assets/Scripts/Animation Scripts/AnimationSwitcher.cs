using System;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
   [SerializeField] private PlayerAppearance _playerAppearance;
   [SerializeField] private Animator _selectedAnimator;

   private void OnEnable()
   {
      _playerAppearance.OnNewSkinShowed += ProcessNewItemSignal;
   }

   private void OnDisable()
   {
      _playerAppearance.OnNewSkinShowed -= ProcessNewItemSignal;
   }

   private void ProcessNewItemSignal(object sender, Appearance appearance)
   {
      if (appearance is Weapon weapon)
      {
         _selectedAnimator.Play(weapon.WeaponHandlingAnimation);
      }
   }
}
