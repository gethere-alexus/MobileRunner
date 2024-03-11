using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.Shop.Shop;
using Sources.StaticData;
using Sources.UI.Elements.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Interaction.MainButton.StateMachine.States
{
    public class PurchaseButtonState<TItem> : IShopMainButtonState where TItem : ItemStaticData
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IShopRepresenter<TItem> _shopRepresenter;
        
        private readonly Button _targetButton;
        private GameObject _buttonInstance;

        public PurchaseButtonState(Button interactionButton, IAssetProvider assetProvider,
            IShopRepresenter<TItem> shopRepresenter)
        {
            _targetButton = interactionButton;
            _assetProvider = assetProvider;
            _shopRepresenter = shopRepresenter;
        }

        public void Enter(ItemData itemData)
        {
            _buttonInstance = _assetProvider.Instantiate(AssetsPaths.PurchaseButton, 
                _targetButton.transform);
            
            _buttonInstance.GetComponent<PurchaseButton>()
                .ConstructButton(itemData.ItemInformation.Price, _targetButton);
            
            _targetButton.onClick.AddListener(_shopRepresenter.ShopInstance.PurchaseShowedItem);
        }

        public void Exit()
        {
            if (_buttonInstance != null)
                Object.Destroy(_buttonInstance);
            
            _targetButton.onClick.RemoveAllListeners();
        }
    }
}