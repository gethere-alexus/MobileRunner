using Infrastructure.SceneLoad;
using Infrastructure.Services.Factory;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _gameIuiFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory gameIuiFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameIuiFactory = gameIuiFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }
        
        private void OnLoaded()
        {
        }

        public void Exit()
        {
            
        }
        
    }
}