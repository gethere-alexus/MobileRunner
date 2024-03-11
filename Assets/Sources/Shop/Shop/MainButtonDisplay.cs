using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.ServiceLocating;
using Sources.Data;
using Sources.StaticData;
using Sources.UI.Interaction.MainButton.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Shop.Shop
{
    public class MainButtonDisplayBase<TItem> : DisplayBase<TItem> where TItem : ItemStaticData
    {
        [SerializeField] private Button _interactionButton;
        
        private ButtonStateMachine<TItem> _buttonStateMachine;

        protected override void SubscribeEvents()
        {
            _buttonStateMachine = new ButtonStateMachine<TItem>(ShopRepresenter, _interactionButton, ServiceLocator.Container.Single<IAssetProvider>());
            ShopRepresenter.ShopInstance.NewItemPreviewed += ConstructButton;
        }
        protected override void UnsubscribeEvents()
        {
            ShopRepresenter.ShopInstance.NewItemPreviewed -= ConstructButton;
        }

        protected override void ConstructDisplay(ItemData item) => 
            _buttonStateMachine.EnterButtonState(item);

        private void ConstructButton(ItemData obj)
        {
            _buttonStateMachine.EnterButtonState(obj);
        }
        
    }
}