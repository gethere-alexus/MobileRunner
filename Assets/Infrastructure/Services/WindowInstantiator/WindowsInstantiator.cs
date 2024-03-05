using Infrastructure.Services.Factory.UI;
using Sources.UI.Windows;

namespace Infrastructure.Services.WindowInstantiator
{
    public class WindowsInstantiator : IWindowInstantiator
    {
        private readonly IUIFactory _factory;


        public WindowsInstantiator(IUIFactory factory)
        {
            _factory = factory;
        }

        public void InstantiateWindow(WindowID id)
        {
            switch (id)
            {
                case WindowID.Shop :
                    _factory.CreateShopWindow();
                    break;
            }
        }
    }
}