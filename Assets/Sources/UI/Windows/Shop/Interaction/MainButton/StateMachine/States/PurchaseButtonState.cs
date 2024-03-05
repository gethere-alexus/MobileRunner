using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.Shop;
using Sources.StaticData;
using Sources.UI.Elements.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine.States
{
    public class PurchaseButtonState<TItem> : IShopMainButtonState<TItem> where TItem : ItemStaticData
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IShopRepresenter _shopRepresenter;
        
        private readonly Button _targetButton;
        private GameObject _buttonInstance;

        public PurchaseButtonState(Button interactionButton, IAssetProvider assetProvider,
            IShopRepresenter shopRepresenter)
        {
            _targetButton = interactionButton;
            _assetProvider = assetProvider;
            _shopRepresenter = shopRepresenter;
        }

        public void Enter(ItemData<TItem> itemData)
        {
            _buttonInstance = _assetProvider.Instantiate(AssetsPaths.PurchaseButton, 
                _targetButton.transform);
            
            _buttonInstance.GetComponent<PurchaseButton>()
                .ConstructButton(itemData.ItemInformation.Price, _targetButton);
            
            _targetButton.onClick.AddListener(_shopRepresenter.SkinShopInstance.PurchaseShowedItem);
        }

        public void Exit()
        {
            if (_buttonInstance != null)
                Object.Destroy(_buttonInstance);
            
            _targetButton.onClick.RemoveAllListeners();
        }
    }
}