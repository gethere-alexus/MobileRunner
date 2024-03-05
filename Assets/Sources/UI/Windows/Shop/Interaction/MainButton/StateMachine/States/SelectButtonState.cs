using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.Shop;
using Sources.UI.Elements.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine.States
{
    public class SelectButtonState : IShopMainButtonState
    {
        private readonly Button _interactionButton;
        private readonly IAssetProvider _assetProvider;
        private readonly IShopRepresenter _shopRepresenter;
        private GameObject _buttonInstance;

        public SelectButtonState(Button interactionButton, IAssetProvider assetProvider,
            IShopRepresenter shopRepresenter)
        {
            _interactionButton = interactionButton;
            _assetProvider = assetProvider;
            _shopRepresenter = shopRepresenter;
        }

        public void Enter(ItemData itemData)
        {
            _buttonInstance = _assetProvider.Instantiate(AssetsPaths.SelectButton, _interactionButton.transform);
            _buttonInstance.GetComponent<SelectButton>().ConstructButton(_interactionButton);
            
            _interactionButton.onClick.AddListener(_shopRepresenter.SkinShopInstance.SelectShowedItem);
        }

        public void Exit()
        {
            if (_buttonInstance != null)
                Object.Destroy(_buttonInstance);
            _interactionButton.onClick.RemoveAllListeners();
        }
    }
}