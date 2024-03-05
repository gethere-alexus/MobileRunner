using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.StateMachine
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : class, IGameState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}