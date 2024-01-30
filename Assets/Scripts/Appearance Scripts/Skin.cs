using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected int _price;
    [SerializeField] protected Boost[] _appliedBoosts;
    
    public Boost[] AppliedBoosts => _appliedBoosts;
    public string Name => _name;
    public int Price => _price;
}
