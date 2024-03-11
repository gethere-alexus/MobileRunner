using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.Shop.Shop;
using Sources.StaticData;
using Sources.UI.Elements.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Interaction.MainButton.StateMachine.States
{
    public class SelectButtonState<TItem> : IShopMainButtonState where TItem : ItemStaticData
    {
        private readonly Button _interactionButton;
        private readonly IAssetProvider _assetProvider;
        private readonly IShopRepresenter<TItem> _shopRepresenter;
        private GameObject _buttonInstance;

        public SelectButtonState(Button interactionButton, IAssetProvider assetProvider,
            IShopRepresenter<TItem> shopRepresenter)
        {
            _interactionButton = interactionButton;
            _assetProvider = assetProvider;
            _shopRepresenter = shopRepresenter;
        }

        public void Enter(ItemData itemData)
        {
            _buttonInstance = _assetProvider.Instantiate(AssetsPaths.SelectButton, _interactionButton.transform);
            _buttonInstance.GetComponent<SelectButton>().ConstructButton(_interactionButton);
            
            _interactionButton.onClick.AddListener(_shopRepresenter.ShopInstance.SelectShowedItem);
        }

        public void Exit()
        {
            if (_buttonInstance != null)
                Object.Destroy(_buttonInstance);
            _interactionButton.onClick.RemoveAllListeners();
        }
    }
}