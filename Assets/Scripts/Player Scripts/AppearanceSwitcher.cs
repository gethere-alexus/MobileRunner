using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum BodyParts {Head,Body,Weapon}
public class AppearanceSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerAppearance _playerAppearance;
    [SerializeField] private AppearanceShop _appearanceShop;
    
    [SerializeField] private List<Head> _heads;
    [SerializeField] private List<Body> _bodies;
    [SerializeField] private List<Weapon> _weapons;
    
    [SerializeField] private Appearance _showedAppearance;

    private Dictionary<BodyParts, List<Appearance>> _bodyPartsLists;
    
    [SerializeField] private BodyParts _modifyingBodyPart;
    private int _modifyingSkinIndex;

    private void Awake()
    {
        _heads = ((Head[]) Sorter.SortPartByPrice(_heads.ToArray())).ToList();
        _bodies = ((Body[]) Sorter.SortPartByPrice(_bodies.ToArray())).ToList();
        _weapons = ((Weapon[]) Sorter.SortPartByPrice(_weapons.ToArray())).ToList();
        
        _bodyPartsLists = new Dictionary<BodyParts, List<Appearance>>()
        {
            { BodyParts.Head, _heads.Cast<Appearance>().ToList() },
            { BodyParts.Body, _bodies.Cast<Appearance>().ToList() },
            { BodyParts.Weapon, _weapons.Cast<Appearance>().ToList() }
        };
    }
    private void OnEnable()
    {
        _playerAppearance.OnNewSkinShowed += ProcessSkinShowSignal;
    }
    private void OnDisable()
    {
        _playerAppearance.OnNewSkinShowed -= ProcessSkinShowSignal;
    }
    private void ProcessSkinShowSignal(object sender, Appearance appearance) => _showedAppearance = appearance;
    public void SetObservingBodyPart(int bodyPart) // used int because unity inspector is not showing enum
    {
        _playerAppearance.ShowSelectedSkin(_modifyingBodyPart);
        _modifyingBodyPart = _bodyPartsLists.ElementAt(bodyPart).Key;
        _playerAppearance.ShowSelectedSkin(_modifyingBodyPart);
        _modifyingSkinIndex = _bodyPartsLists[_modifyingBodyPart].IndexOf(_playerAppearance.GetSelectedSkin(_modifyingBodyPart));

    }
    public void ShowNextSkin()
    {
        bool isBeyondLimits = _modifyingSkinIndex + 1 >= _bodyPartsLists[_modifyingBodyPart].Count;
        _modifyingSkinIndex = isBeyondLimits ? 0 : _modifyingSkinIndex + 1;
        
        _playerAppearance.ShowSkin(_bodyPartsLists[_modifyingBodyPart][_modifyingSkinIndex]);
    }
    public void ShowPreviousSkin()
    {
        _modifyingSkinIndex = _modifyingSkinIndex - 1 < 0 ? _bodyPartsLists[_modifyingBodyPart].Count - 1 : _modifyingSkinIndex - 1;
       
        _playerAppearance.ShowSkin(_bodyPartsLists[_modifyingBodyPart][_modifyingSkinIndex]);
    }
    public void SelectShowedSkin() => _playerAppearance.SelectSkin(_showedAppearance);
    public Appearance ShowedAppearance => _showedAppearance;
}
