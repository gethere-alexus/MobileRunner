using Sources.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.UI.Windows.Shop
{
    public class ShowedCharacterDisplay : MonoBehaviour
    {
        private const int PreviewLayer = 6;

        [FormerlySerializedAs("_shopDisplay")] [FormerlySerializedAs("_shopPresenterDisplay")] [SerializeField] private SkinShopDisplay _skinShopDisplay;

        private GameObject _playerInstance, _particlesInstance;

        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _skinShopDisplay.ShopInitialized += SubscribeSkinShopEvents;
        }

        private void SubscribeSkinShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _skinShopDisplay.SkinSkinShopInstance.NewItemPreviewed += ConstructPreview;
                _isShopEventsSubscribed = true;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _skinShopDisplay.SkinSkinShopInstance.NewItemPreviewed -= ConstructPreview;
                _isShopEventsSubscribed = false;
            }
        }

        private void ConstructPreview(ItemData e)
        {
            InstantiateParticles(e.ItemInformation.ItemRarity.RarityParticle.gameObject);
            InstantiateCharacter(e.ItemInformation.ItemPrefab);
        }

        private void InstantiateCharacter(GameObject character)
        {
            if (_playerInstance != null)
                Destroy(_playerInstance);

            _playerInstance = Instantiate(character, _skinShopDisplay.PreviewSpace);
            SetObjLayer(_playerInstance, PreviewLayer);
        }

        private void InstantiateParticles(GameObject particles)
        {
            if (_particlesInstance != null)
                Destroy(_particlesInstance);
            
            _particlesInstance = Instantiate(particles, _skinShopDisplay.PreviewSpace);
            SetObjLayer(_particlesInstance, PreviewLayer);
        }

        private void SetObjLayer(GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}