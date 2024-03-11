using Sources.Data;
using Sources.StaticData;
using UnityEngine;

namespace Sources.Shop.Shop
{
    public abstract class PreviewDisplayBase<TItem> : DisplayBase<TItem> where TItem : ItemStaticData
    {
        private const int PreviewLayer = 6;

        private GameObject _playerInstance;
        private GameObject _particlesInstance;

        protected override void ConstructDisplay(ItemData item)
        {
            InstantiateParticles(item.ItemInformation.ItemRarity.RarityParticle.gameObject);
            InstantiateCharacter(item.ItemInformation.ItemPrefab);
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            ShopRepresenter.ShopInstance.NewItemPreviewed += ConstructDisplay;
            
            if (_particlesInstance != null)
                _particlesInstance.SetActive(true);
            if (_playerInstance != null)
                _playerInstance.SetActive(true);
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            ShopRepresenter.ShopInstance.NewItemPreviewed -= ConstructDisplay;
            
            if (_particlesInstance != null)
                _particlesInstance.SetActive(false);
            if (_playerInstance != null)
                _playerInstance.SetActive(false);
            
        }

        private void DestroyObject(GameObject obj)
        {
            if (obj != null)
                Destroy(obj);
        }

        private void InstantiateCharacter(GameObject character)
        {
            DestroyObject(_playerInstance);

            _playerInstance = Instantiate(character, ShopRepresenter.PreviewSpace);
            SetObjectLayer(_playerInstance, PreviewLayer);
        }

        private void InstantiateParticles(GameObject particles)
        {
            DestroyObject(_particlesInstance);

            _particlesInstance = Instantiate(particles, ShopRepresenter.PreviewSpace);
            SetObjectLayer(_particlesInstance, PreviewLayer);
        }

        private void SetObjectLayer(GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}