using Infrastructure.Data;
using Infrastructure.SceneLoad;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory;
using Infrastructure.Services.InputService;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Bootstrap";

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
            
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IProgressProvider>(new PersistentDataService());
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
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }
    }
} 