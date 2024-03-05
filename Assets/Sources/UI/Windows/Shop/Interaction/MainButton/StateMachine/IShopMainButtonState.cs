using Infrastructure.StateMachine;
using Sources.Data;
using Sources.StaticData;

namespace Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine
{
    public interface IShopMainButtonState<TItem> : IExitableState where TItem : ItemStaticData
    {
        void Enter(ItemData<TItem> itemData);
    }
    
}