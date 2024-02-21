using Infrastructure.ServiceLocating;

namespace Infrastructure.Factory
{
    public interface IFactory : IService
    {
        public void CreateMainMenu();
    }
}