using Infrastructure.StateMachine.States;
using UnityEngine;

namespace Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _gameInstance;

        private void Awake()
        {
            _gameInstance = new Game(this);
            _gameInstance.StateMachine.Enter<BootstrapGameState>();
            
            DontDestroyOnLoad(this);
        }
    }
}