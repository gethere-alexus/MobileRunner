using System;
using System.Collections.Generic;
using Infrastructure.SceneLoad;
using Infrastructure.Services.Factory;
using Infrastructure.Services.ServiceLocating;
using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, serviceLocator),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, serviceLocator.Single<IFactory>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this)
            };
        }

        // Enter state without payload
        public void Enter<TState>() where TState : class, IState =>
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