using Appearance_Scripts;
using UnityEngine;

namespace UI_Scripts
{
   public class UICharacterPreview : MonoBehaviour
   {
      [SerializeField] private Transform _charPreviewStorage;
      [SerializeField] private PlayerSkin _playerSkin;
   
      private GameObject _playerInstance, _particlesInstance;

      private void OnEnable()
      { 
         _playerSkin.OnNewSkinShowed += ConfigureCharacterPreview;
      }
      private void OnDisable()
      {
         _playerSkin.OnNewSkinShowed -= ConfigureCharacterPreview;
      }

      private void ConfigureCharacterPreview(object sender, Skin e)
      {
         if(_particlesInstance != null) Destroy(_playerInstance);
         if(_playerInstance != null) Destroy(_particlesInstance);
      
         _playerInstance = Instantiate(e.gameObject, _charPreviewStorage);
         _particlesInstance = Instantiate(e.ItemRarity.RarityParticle.gameObject, _charPreviewStorage);
      }
   }
}
