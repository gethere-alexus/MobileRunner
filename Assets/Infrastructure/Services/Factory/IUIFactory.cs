using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        void CreateUIMenu();
        void CreateShopWindow();
    }
}