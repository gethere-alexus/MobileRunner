using System.Collections.Generic;
using Infrastructure.Services.AssetManagement;
using Sources.Data;
using Sources.Shop;
using Sources.Shop.ShopRepresenters;
using Sources.StaticData;
using Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine.States;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine
{
    public class ButtonStateMachine<TItem> where TItem : ItemStaticData
    {
        private readonly Dictionary<ItemStatus, IShopMainButtonState> _states;
        private IShopMainButtonState _activeState;

        public ButtonStateMachine(IShopRepresenter<TItem> shopRepresenter, Button interactionButton, IAssetProvider assetProvider)
        {
            _states = new Dictionary<ItemStatus, IShopMainButtonState>()
            {
                { ItemStatus.Purchasable, new PurchaseButtonState<TItem>(interactionButton, assetProvider,shopRepresenter) },
                { ItemStatus.Selectable, new SelectButtonState<TItem>(interactionButton, assetProvider, shopRepresenter) },
                { ItemStatus.Selected, new SelectedButtonState(interactionButton, assetProvider)}
            };
        }

        public void EnterButtonState(ItemData itemData) => 
            ChangeState(itemData);

        private void ChangeState(ItemData itemData)
        {
            _activeState?.Exit();
            _activeState = _states[itemData.ItemStatus];
            _activeState.Enter(itemData);
        }
    }
}