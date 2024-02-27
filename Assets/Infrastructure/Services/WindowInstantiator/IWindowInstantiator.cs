using Infrastructure.Services.ServiceLocating;
using Sources.UI.Windows;

namespace Infrastructure.Services.WindowInstantiator
{
    public interface IWindowInstantiator : IService
    {
        void InstantiateWindow(WindowID id);
    }
}