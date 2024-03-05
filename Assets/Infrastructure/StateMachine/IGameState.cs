using System;

namespace Infrastructure.StateMachine
{
    public interface IGameState : IExitableState
    {
        void Enter();
    }
}