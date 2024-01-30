using UnityEngine;
public class AppearanceSwitcher : MonoBehaviour
{
    private void Awake()
    {
    }
    private void OnEnable()
    {
        //_playerAppearance.OnNewSkinShowed += ProcessSkinShowSignal;
    }
    private void OnDisable()
    {
       // _playerAppearance.OnNewSkinShowed -= ProcessSkinShowSignal;
    }

    private void ProcessSkinShowSignal(object sender, Skin skin)
    {
        
    }
    public void ShowNextSkin()
    {
    }
    public void ShowPreviousSkin()
    {
    }

    public void SelectShowedSkin()
    {
        
    }
}
