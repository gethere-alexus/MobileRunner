using System.Collections.Generic;
using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.Shop;
using Sources.StaticData;
using Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine.States;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine
{
    public class ButtonStateMachine<TItem> where TItem : ItemStaticData
    {
        private readonly Dictionary<ItemStatus, IShopMainButtonState<TItem>> _states;
        private IShopMainButtonState<TItem> _activeState;

        public ButtonStateMachine(IShopRepresenter shopRepresenter, Button interactionButton, IAssetProvider assetProvider)
        {
            _states = new Dictionary<ItemStatus, IShopMainButtonState<TItem>>()
            {
                { ItemStatus.Purchasable, new PurchaseButtonState<TItem>(interactionButton, assetProvider,shopRepresenter) },
                { ItemStatus.Selectable, new SelectButtonState<TItem>(interactionButton, assetProvider, shopRepresenter) },
                { ItemStatus.Selected, new SelectedButtonState<TItem>(interactionButton, assetProvider)}
            };
        }

        public void EnterButtonState(ItemData<TItem> itemData) => 
            ChangeState(itemData);

        private void ChangeState(ItemData<TItem> itemData)
        {
            _activeState?.Exit();
            _activeState = _states[itemData.ItemStatus];
            _activeState.Enter(itemData);
        }
    }
}