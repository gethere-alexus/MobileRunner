using Sources.UI;
using UnityEngine;

namespace Sources.UI_Scripts
{
   public class SectionSwitch : MonoBehaviour
   {
      [SerializeField] private Section[] _sections;
      [SerializeField] private int _startSectionIndex;
      private Section _activeSection;

      private void Awake()
      {
         foreach (var section in _sections)
         {
            section.SelectionButton.onClick.AddListener(() => OpenSection(section));
         }
         OpenSection(_sections[_startSectionIndex]);
      }
      
      private void OpenSection(Section section)
      {
         _activeSection?.SetActive(false);
         
         _activeSection = section;
         section.SetActive(true);
      }
   }
}
