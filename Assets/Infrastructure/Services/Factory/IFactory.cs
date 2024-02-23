using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.Services.Factory
{
    public interface IFactory : IService
    {
        public void CreateMainMenu();
    }
}