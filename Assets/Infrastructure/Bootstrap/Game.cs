using Infrastructure.SceneLoad;
using Infrastructure.ServiceLocating;
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