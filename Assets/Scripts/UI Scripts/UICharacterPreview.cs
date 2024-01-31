using UnityEngine;

public class UICharacterPreview : MonoBehaviour
{
   [SerializeField] private PlayerSkin _playerSkin;
   [SerializeField] private Transform _charPreviewStorage;
   
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
