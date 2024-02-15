using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Infrastructure.GlobalEventBus;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Sources.Player
{
    public class PlayerStatsRepresent : MonoBehaviour
    {
        [SerializeField] private PlayerStat[] _playerStats;

        private void OnEnable()
        {
            GlobalEventBus.Sync.Subscribe<OnBoostApplied>(OnBoostApplied);
            GlobalEventBus.Sync.Subscribe<OnBoostRemoved>(OnBoostRemoved);
        }

        private void OnDisable()
        {
            GlobalEventBus.Sync.Unsubscribe<OnBoostApplied>(OnBoostApplied);
            GlobalEventBus.Sync.Unsubscribe<OnBoostRemoved>(OnBoostRemoved);
        }

        private void OnBoostApplied(object sender, EventArgs e)
        {
            OnBoostApplied ctx = (OnBoostApplied)e;
            GetBoostRepresent(ctx.Boost.BoostData).IncrementBoostingValue(ctx.Boost.BoostValue);
        }

        private void OnBoostRemoved(object sender, EventArgs e)
        {
            OnBoostRemoved ctx = (OnBoostRemoved)e;
            GetBoostRepresent(ctx.Boost.BoostData).DecrementBoostingValue(ctx.Boost.BoostValue);
        }

        public Dictionary<BoostDataContainer, int> GetBoostImpacts()
        {
            Dictionary<BoostDataContainer, int> toReturn = new Dictionary<BoostDataContainer, int>();
            foreach (var playerStat in _playerStats)
            {
                toReturn.Add(playerStat.ApplicableBoost, playerStat.BoostImpact);
            }

            return toReturn;
        }

        public Dictionary<BoostDataContainer, int> GetBoostableValues()
        {
            Dictionary<BoostDataContainer, int> toReturn = new Dictionary<BoostDataContainer, int>();
            foreach (var playerStat in _playerStats)
            {
                toReturn.Add(playerStat.ApplicableBoost, playerStat.BoostableValue);
            }

            return toReturn;
        }

        public PlayerStat GetBoostRepresent(BoostDataContainer boost) =>
            _playerStats.First(value => value.ApplicableBoost == boost);

        public PlayerStat[] PlayerStats => _playerStats;
    }
}