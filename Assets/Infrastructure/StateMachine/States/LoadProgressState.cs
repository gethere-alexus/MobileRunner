using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;

namespace Infrastructure.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoad;

        public LoadProgressState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
        {
            _saveLoad = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            ConstructProgress();
            _gameStateMachine.Enter<LoadMenuState>();
        }

        public void Exit()
        {
            
        }
        private void ConstructProgress() =>
            ServiceLocator.Container.Single<IProgressProvider>().PlayerProgressData =
                _saveLoad.LoadProgress() ?? InitNewProgress();

        private PlayerProgress InitNewProgress()
        {
            var toReturn = new PlayerProgress
            {
                Money = 500600700
            };

            return toReturn;
        }
    }
}