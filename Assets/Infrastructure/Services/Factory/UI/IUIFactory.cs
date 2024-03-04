using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.Factory.UI
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        void CreateMainMenu();
        void CreateShopWindow();
        void ClearObservers();
    }
}