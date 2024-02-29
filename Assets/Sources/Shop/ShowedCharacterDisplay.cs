using Sources.Data;
using UnityEngine;

namespace Sources.Shop
{
    public class ShowedCharacterDisplay : MonoBehaviour
    {
        private const int PreviewLayer = 6;

        [SerializeField] private ItemShopDisplay _shopDisplay;

        private GameObject _playerInstance, _particlesInstance;

        private bool _isShopEventsSubscribed;

        private void OnEnable()
        {
            _shopDisplay.ShopInitialized += SubscribeShopEvents;
        }

        private void SubscribeShopEvents()
        {
            if (!_isShopEventsSubscribed)
            {
                _shopDisplay.SkinShopInstance.NewItemPreviewed += ConstructPreview;
                _isShopEventsSubscribed = true;
            }
        }

        private void OnDisable()
        {
            if (_isShopEventsSubscribed)
            {
                _shopDisplay.SkinShopInstance.NewItemPreviewed -= ConstructPreview;
                _isShopEventsSubscribed = false;
            }
        }

        private void ConstructPreview(ItemData e)
        {
            InstantiateParticles(e.ItemStaticDataInformation.ItemRarity.RarityParticle.gameObject);
            InstantiateCharacter(e.ItemStaticDataInformation.ItemPrefab);
        }

        private void InstantiateCharacter(GameObject character)
        {
            if (_playerInstance != null)
                Destroy(_playerInstance);

            _playerInstance = Instantiate(character, _shopDisplay.PreviewSpace);
            SetObjLayer(_playerInstance, PreviewLayer);
        }

        private void InstantiateParticles(GameObject particles)
        {
            if (_particlesInstance != null)
                Destroy(_particlesInstance);
            
            _particlesInstance = Instantiate(particles, _shopDisplay.PreviewSpace);
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