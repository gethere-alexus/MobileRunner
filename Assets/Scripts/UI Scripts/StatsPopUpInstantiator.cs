using UnityEngine;

public class StatsPopUpInstantiator : PopUpInstantiator
{
    
    public override void InstantiatePopUp()
    {
        StatsPopUp popUpConf = Instantiate(_popUpPrefab).GetComponent<StatsPopUp>();
        popUpConf.Configure();
    }
}
