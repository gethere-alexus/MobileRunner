using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.ServiceLocating;
using Sources.Player;
using Sources.StaticData;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private const int BaseStatValue = 100;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoad;
        private readonly IAssetProvider _assetsProvider;

        public LoadProgressState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService,
            IAssetProvider assetsProvider)
        {
            _saveLoad = saveLoadService;
            _gameStateMachine = gameStateMachine;
            _assetsProvider = assetsProvider;
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
                SelectedSkin = "Invader",
                PurchasedSkins = new []{ "Invader"},
                PlayerStatistics = ConstructStatistics(BaseStatValue)
            };

            return toReturn;
        }

        private Statistic[] ConstructStatistics(int baseValue)
        {
            StatisticDescription[] statDescriptions =
                _assetsProvider.LoadAll<StatisticDescription>(AssetsPaths.StatDescriptions);
            List<Statistic> toReturn = new List<Statistic>();
            foreach (var statDescription in statDescriptions)
            {
                Statistic toAdd = new Statistic(statDescription, baseValue);
                toReturn.Add(toAdd);
            }
            return toReturn.ToArray();
        }
    }
}