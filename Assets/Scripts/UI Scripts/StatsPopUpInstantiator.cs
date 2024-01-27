using UnityEngine;

public class StatsPopUpInstantiator : PopUpInstantiator
{
    [SerializeField] private PlayerStatsRepresenter _playerStatsRepresenter;
    public override void InstantiatePopUp()
    {
        StatsPopUp popUpConf = Instantiate(_popUpPrefab).GetComponent<StatsPopUp>();
        popUpConf.Configure(_playerStatsRepresenter.GetBoostImpacts(), _playerStatsRepresenter.GetBoostableValues());
    }
}
