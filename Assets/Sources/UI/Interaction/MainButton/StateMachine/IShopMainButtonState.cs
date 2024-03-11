using Infrastructure.StateMachine;
using Sources.Data;

namespace Sources.UI.Interaction.MainButton.StateMachine
{
    public interface IShopMainButtonState : IExitableState 
    {
        void Enter(ItemData itemData);
    }
    
}