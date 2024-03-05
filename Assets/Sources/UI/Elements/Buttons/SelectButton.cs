using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Buttons
{
    public class SelectButton : MonoBehaviour
    {
        [SerializeField] private Image _targetGraphic;

        public void ConstructButton(Button targetButton) => targetButton.targetGraphic = _targetGraphic;
    }
}