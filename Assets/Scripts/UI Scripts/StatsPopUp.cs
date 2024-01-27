using System.Collections.Generic;
using UnityEngine;

public class StatsPopUp : PopUp
{
    [SerializeField] private GameObject _contentFitter;
    [SerializeField] private BoostDescription _boostDescriptionTemplate;

    public void Configure(Dictionary<BoostDataContainer, int> boostImpacts, Dictionary<BoostDataContainer, int> boostableValues)
    {
        foreach (var boostImpact in boostImpacts)
        {
            BoostDescription boostDescription = Instantiate(_boostDescriptionTemplate, _contentFitter.transform);
            boostDescription.ConfigureDescription(boostImpact.Key.BoostSprite, boostImpact.Value, boostableValues[boostImpact.Key], BoostDescription.BoostTextFormat.boostFirst);
        }
    }
}
