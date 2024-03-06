using System;
using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;
using Sources.Player;
using Sources.StaticData;
using Sources.StaticData.CharacterTypes;

namespace Infrastructure.StateMachine.States
{
    public class LoadProgressGameState : IGameState
    {
        private const int BaseStatValue = 100;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoad;

        public LoadProgressGameState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
        {
            _saveLoad = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            ConstructProgress();
            _gameStateMachine.Enter<LoadMenuGameState>();
        }

        public void Exit()
        {
            
        }

        private void ConstructProgress() =>
            ServiceLocator.Container.Single<IProgressProvider>()
                .UpdateData(_saveLoad.LoadProgress() ?? InitNewProgress());

        private PlayerProgress InitNewProgress()
        {
            var toReturn = new PlayerProgress
            {
                Money = 500600700,
                Level = 3,
                CurrentXp = 150,
                RequiredXp = 500,
                SelectedSkin = CharacterType.Invader,
                PurchasedSkins = new [] { CharacterType.Invader },
                StatValues = ConstructStats(BaseStatValue)
            };

            return toReturn;
        }

        private StatisticData[] ConstructStats(int baseStatValue)
        {
            List<StatisticData> statisticData = new();
            
            foreach (StatisticType type in Enum.GetValues(typeof(StatisticType)))
                statisticData.Add(new StatisticData(type,baseStatValue));
            
            return statisticData.ToArray();
        }
    }
}