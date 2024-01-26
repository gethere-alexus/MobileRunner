using UnityEngine;
using UnityEngine.UI;

public class ButtonColorPicker : MonoBehaviour
{
   [SerializeField] private bool _isButtonPressed = false;
   [SerializeField] private Sprite _idleButtonSprite, _selectedButtonSprite;

   public void ProcessButtonPress()
   {
      _isButtonPressed = true;
      UpdateButtonSprite();
   }

   public void SetPressStatus(bool isPressed)
   {
      _isButtonPressed = isPressed;
      UpdateButtonSprite();
   }

   private void UpdateButtonSprite()
   {
      this.gameObject.GetComponent<Image>().sprite = _isButtonPressed ? _selectedButtonSprite : _idleButtonSprite;
   }
}
