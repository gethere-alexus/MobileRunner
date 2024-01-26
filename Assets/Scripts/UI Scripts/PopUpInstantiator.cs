using UnityEngine;

public class PopUpInstantiator : MonoBehaviour
{
    [SerializeField] protected GameObject _popUpPrefab;

    public virtual void InstantiatePopUp()
    {
        PopUp popUpConfigurator = Instantiate(_popUpPrefab).GetComponent<PopUp>();
    }
}
