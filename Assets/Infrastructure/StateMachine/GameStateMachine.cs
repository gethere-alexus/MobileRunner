using System;
using System.Collections.Generic;
using FMOD;
using Infrastructure.SceneLoad;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Factory.UI;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;
using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapGameState)] = new BootstrapGameState(this, sceneLoader, serviceLocator),
                [typeof(LoadProgressGameState)] = new LoadProgressGameState(this, ServiceLocator.Container.Single<ISaveLoadService>()),
                [typeof(LoadMenuGameState)] = new LoadMenuGameState(serviceLocator.Single<IUIFactory>(), sceneLoader),
                [typeof(LoadRunGameState)] = new LoadRunGameState(sceneLoader)
            };
        }

        // Enter state without payload
        public void Enter<TState>() where TState : class, IGameState =>
            ChangeState<TState>().Enter();

        // Enter state with payload
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> =>
            ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        // Get state with down-casting 
        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}