using Infrastructure.SceneLoad;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Bootstrap";
        private const string StartScene = "MainMenu";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log("Register services...");
            _sceneLoader.Load(Initial, OnLoaded);
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadLevelState, string>(StartScene);
        }

        public void Exit()
        {
        }
    }
} 