using UnityEngine;
using UnityEngine.UI;

public class ShopSectionSwitcher : MonoBehaviour
{
   [SerializeField] private ShopSection[] _shopSections;
   private ShopSection _currentShopSection;


   public void OnSectionOpening(Button sender)
   {
      foreach (var section in _shopSections)
      {
         if (section.OpenButton == sender)
         {
            OpenShopSection(section);
         }
      }
   }
   private void OpenShopSection(ShopSection shopSection)
   {
      if(_currentShopSection != null) SetCurrentSectionActive(false);
      _currentShopSection = shopSection;
      SetCurrentSectionActive(true);
   }

   private void SetCurrentSectionActive(bool status)
   {
      _currentShopSection.OpenButton.GetComponent<ButtonColorPicker>().SetPressStatus(status);
      _currentShopSection.Section.gameObject.SetActive(status);
   }
}
