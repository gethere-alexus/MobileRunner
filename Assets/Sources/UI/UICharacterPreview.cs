using Sources.Data;
using Sources.Shop;
using UnityEngine;

namespace Sources.UI
{
    public class UICharacterPreview : MonoBehaviour
    {
        [SerializeField] private Transform _charPreviewStorage;
        [SerializeField] private ItemShopDisplay _charactersShopDisplay;

        private GameObject _playerInstance, _particlesInstance;

        private void OnEnable()
        {
            _charactersShopDisplay.OnNewItemPreviewed += ConfigureCharacterPreview;
        }

        private void OnDisable()
        {
            _charactersShopDisplay.OnNewItemPreviewed -= ConfigureCharacterPreview;
        }

        private void ConfigureCharacterPreview(object sender, ItemData e)
        {
            if (_particlesInstance != null) Destroy(_playerInstance);
            if (_playerInstance != null) Destroy(_particlesInstance);

            _playerInstance = Instantiate(e.ItemInformation.ItemPrefab, _charPreviewStorage);
            _particlesInstance =
                Instantiate(e.ItemInformation.ItemRarity.RarityParticle.gameObject, _charPreviewStorage);
        }
    }
}