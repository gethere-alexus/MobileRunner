using Infrastructure.PlayerData;
using Infrastructure.Services.ServiceLocating;
using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine
{
    public class LoadProgressState : IState
    {
        private const string MainMenu = "MainMenu";
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            CreateNewProgress();
            _gameStateMachine.Enter<LoadLevelState,string>(MainMenu);
        }

        private void CreateNewProgress()
        {
            IProgressProvider newProgress = ServiceLocator.Container.Single<IProgressProvider>();
            newProgress.Money = 500600700;
        }

        public void Exit()
        {
        }
    }
}