﻿using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.InputService;
using Infrastructure.SceneLoad;
using Infrastructure.ServiceLocating;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Bootstrap";
        private const string StartScene = "MainMenu";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, OnLoaded);
        }

        private void RegisterServices()
        {
            RegisterInputService();
            
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IFactory>(new GameFactory(_services.Single<IAssetProvider>())); 
        }

        private void RegisterInputService()
        {
            var instance = new GameObject().AddComponent<InputProcessor>();
            
            instance.name = "Input Processor";
            
            _services.RegisterSingle<IInputProcessingService>(instance);
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