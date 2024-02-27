using Infrastructure.SceneLoad;

namespace Infrastructure.StateMachine.States
{
    public class LoadRunState : IState
    {
        private const string RunScene = "Run";
        private readonly SceneLoader _sceneLoader;

        public LoadRunState(SceneLoader sceneLoader)
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