using Infrastructure.SceneLoad;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.Factory.Character;
using Infrastructure.Services.Factory.UI;
using Infrastructure.Services.InputService;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.WindowInstantiator;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapGameState : IGameState
    {
        private const string Initial = "Bootstrap";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _services;

        public BootstrapGameState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator services)
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
            
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IStaticDataProvider>(new StaticDataProvider(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService());
            _services.RegisterSingle<IProgressProvider>(new PersistentDataService(_services.Single<ISaveLoadService>()));

            _services.RegisterSingle<ICharacterFactory>(new CharacterFactory(_services.Single<IStaticDataProvider>(), 
                _services.Single<IProgressProvider>(), 
                _services.Single<IInputProcessingService>()));

            _services.RegisterSingle<IUIFactory>(
                new UIFactory(_services.Single<IAssetProvider>(),
                    _services.Single<IProgressProvider>(),
                    _services.Single<IStaticDataProvider>(),
                    _services.Single<ICharacterFactory>()));

            _services.RegisterSingle<IWindowInstantiator>(new WindowsInstantiator(_services.Single<IUIFactory>()));
        }

        private void RegisterInputService()
        {
            var instance = new GameObject().AddComponent<InputProcessor>();
            
            instance.name = "Input Processor";
            
            _services.RegisterSingle<IInputProcessingService>(instance);
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadProgressGameState>();
        }

        public void Exit()
        {
        }
    }
} 