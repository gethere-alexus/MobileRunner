using Sources.Data;
using Sources.Shop;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.UI.Windows.Shop.ItemInformation
{
    public class ShowedCharacterDisplay : MonoBehaviour
    {
        [SerializeField] private SkinShopRepresenter _skinShopRepresenter;

        private const int PreviewLayer = 6;

        private GameObject _playerInstance, _particlesInstance;


        private void OnEnable()
        {
            _skinShopRepresenter.ShopInitialized += SubscribeSkinShopEvents;
            SubscribeSkinShopEvents();
        }

        private void SubscribeSkinShopEvents()
        {
            if (_skinShopRepresenter.SkinShopInstance != null)
            {
                _skinShopRepresenter.SkinShopInstance.NewItemPreviewed += ConstructPreview;
            }
        }

        private void OnDisable()
        {
            if (_skinShopRepresenter.SkinShopInstance != null)
            {
                _skinShopRepresenter.SkinShopInstance.NewItemPreviewed -= ConstructPreview;
            }

            _skinShopRepresenter.ShopInitialized -= SubscribeSkinShopEvents;
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

            _playerInstance = Instantiate(character, _skinShopRepresenter.PreviewSpace);
            SetObjLayer(_playerInstance, PreviewLayer);
        }

        private void InstantiateParticles(GameObject particles)
        {
            if (_particlesInstance != null)
                Destroy(_particlesInstance);

            _particlesInstance = Instantiate(particles, _skinShopRepresenter.PreviewSpace);
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