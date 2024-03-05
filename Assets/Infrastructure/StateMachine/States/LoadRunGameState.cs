using Infrastructure.SceneLoad;

namespace Infrastructure.StateMachine.States
{
    public class LoadRunGameState : IGameState
    {
        private const string RunScene = "Run";
        private readonly SceneLoader _sceneLoader;

        public LoadRunGameState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(RunScene, OnLoaded);
        }

        private void OnLoaded()
        {
        }

        public void Exit()
        {
        }
    }
}