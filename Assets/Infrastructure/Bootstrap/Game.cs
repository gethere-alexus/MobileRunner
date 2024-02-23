using Infrastructure.SceneLoad;
using Infrastructure.Services.ServiceLocating;
using Infrastructure.StateMachine;

namespace Infrastructure.Bootstrap
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new ServiceLocator());
        }
    }
}