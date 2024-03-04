using Infrastructure.SceneLoad;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Factory.UI;

namespace Infrastructure.StateMachine.States
{
    public class LoadMenuState : IState
    {
        private const string MainMenu = "MainMenu";

        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadMenuState(IUIFactory uiFactory, SceneLoader sceneLoader)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter() =>
            _sceneLoader.Load(MainMenu, OnLoaded);

        private void OnLoaded()
        {
            _uiFactory.ClearObservers();
            _uiFactory.CreateMainMenu();
        }

        public void Exit()
        {
        }
    }
}