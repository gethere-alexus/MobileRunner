using Sources.Shop;
using Sources.UI.Elements;
using UnityEngine;

namespace Sources.UI.Interaction
{
    public class SectionSwitch : MonoBehaviour
    {
        [SerializeField] private Section[] _sections;
        [SerializeField, Min(0)] private int _startSectionIndex;
        
        private Section _activeSection;

        public void OpenSection(Section section)
        {
            _activeSection?.SetActive(false);
            _activeSection = section;
            section.SetActive(true);
        }

        private void OnValidate()
        {
            if (_startSectionIndex >= _sections.Length)
                _startSectionIndex = _sections.Length - 1;
        }

        private void Awake()
        {
            foreach (var section in _sections)
            {
                section.SelectionButton.onClick.AddListener(() => OpenSection(section));
            }

            OpenSection(_sections[_startSectionIndex]);
        }
    }
}