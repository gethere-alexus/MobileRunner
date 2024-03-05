using Sources.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Buttons
{
   public class PurchaseButton : MonoBehaviour
   {
      [SerializeField] private TMP_Text _price;
      [SerializeField] private Image _targetGraphic;

      public void ConstructButton(int price, Button targetButton)
      {
         targetButton.targetGraphic = _targetGraphic;
         _price.text = TextFormatter.DivideIntWithChar(price, ',');
      }
      
   }
}
