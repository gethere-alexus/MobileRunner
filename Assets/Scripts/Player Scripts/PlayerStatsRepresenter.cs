using System;
using System.Linq;
using UnityEngine;

public class PlayerStatsRepresenter : MonoBehaviour
{
    
    [SerializeField] private PlayerStat[] _playerStats;

    private void OnEnable()
    {
        GlobalEventBus.Sync.Subscribe<OnBoostApplied>();
        GlobalEventBus.Sync.Subscribe<OnBoostRemoved>();
    }

    private void OnDisable()
    {
        GlobalEventBus.Sync.Unsubscribe<OnBoostApplied>();
        GlobalEventBus.Sync.Unsubscribe<OnBoostRemoved>();
    }

    public PlayerStat GetBoostRepresent(BoostType boost) => _playerStats.First(value => value.AppliableBoost == boost);
    public PlayerStat[] PlayerStats => _playerStats;
}
