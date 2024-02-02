using ScriptableObjects;
using UnityEngine;

namespace UI_Scripts
{
   public class UICharacterPreview : MonoBehaviour
   {
      [SerializeField] private Transform _charPreviewStorage;
      [SerializeField] private CharactersShopDisplay _charactersShopDisplay;
   
      private GameObject _playerInstance, _particlesInstance;

      private void OnEnable()
      { 
         _charactersShopDisplay.SkinShopInstance.OnNewItemPreviewed += ConfigureCharacterPreview;
      }

      private void OnDisable()
      {
         _charactersShopDisplay.SkinShopInstance.OnNewItemPreviewed -= ConfigureCharacterPreview;
      }

      private void ConfigureCharacterPreview(object sender, ItemDataContainer e)
      {
         if(_particlesInstance != null) Destroy(_playerInstance);
         if(_playerInstance != null) Destroy(_particlesInstance);
      
         _playerInstance = Instantiate(e.ItemPrefab, _charPreviewStorage);
         _particlesInstance = Instantiate(e.ItemRarity.RarityParticle.gameObject, _charPreviewStorage);
      }
   }
}
