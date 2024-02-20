using Infrastructure.SceneLoad;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            Object.Instantiate(Resources.Load<GameObject>("Prefabs/UI/Canvas - Main Menu"));
        }

        public void Exit()
        {
            
        }
        
    }
}