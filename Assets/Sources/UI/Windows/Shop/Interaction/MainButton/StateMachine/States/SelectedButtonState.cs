using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine.States
{
    public class SelectedButtonState<TItem> : IShopMainButtonState<TItem> where TItem : ItemStaticData
    {
        private readonly Button _interactionButton;
        private readonly IAssetProvider _assetProvider;
        private GameObject _buttonInstance;

        public SelectedButtonState(Button interactionButton, IAssetProvider assetProvider)
        {
            _interactionButton = interactionButton;
            _assetProvider = assetProvider;
        }

        public void Enter(ItemData<TItem> itemData)
        {
            _buttonInstance = _assetProvider.Instantiate(AssetsPaths.SelectedButton, _interactionButton.transform);
        }

        public void Exit()
        {
            if(_buttonInstance != null)
                Object.Destroy(_buttonInstance);
        }
    }
}