namespace Infrastructure.Services.ServiceLocating
{
    // Self-made Dependency Injection realization.
    // Created in educational purpose, to understand how DI frameworks (Zenject, etc.) basically works.
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Container => _instance ??= new ServiceLocator();
        
        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.Instance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.Instance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService Instance;
        }
    }
 }