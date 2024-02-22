﻿using Infrastructure.Factory;
using Infrastructure.SceneLoad;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IFactory gameFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);
        
        private void OnLoaded()
        {
            _gameFactory.CreateMainMenu();
        }

        public void Exit()
        {
            
        }
        
    }
}