using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoostDescription : MonoBehaviour
{
    public enum BoostTextFormat {boostFirst,FinalValueFirst}
    [SerializeField] private Image _boostImage;

    [SerializeField] private TMP_Text _boostDescription;

    public void ConfigureDescription(Sprite image, int boostValue, int valueAfterBoost, BoostTextFormat textFormat = BoostTextFormat.boostFirst)
    {
        string description = textFormat switch
        {
            BoostTextFormat.boostFirst =>
                $"+{boostValue} ({valueAfterBoost})",
            BoostTextFormat.FinalValueFirst =>
                $"{valueAfterBoost} (+{boostValue})",
            _ => $"{boostValue} ({valueAfterBoost})"
        };

        _boostDescription.text = description;
        _boostImage.sprite = image;
    }
}
