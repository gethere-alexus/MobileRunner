using UnityEngine;

namespace Sources.Shop
{
    public class SectionSwitch : MonoBehaviour
    {
        [SerializeField] private ShopSection[] _sections;
        [SerializeField, Min(0)] private int _startSectionIndex;
        
        private ShopSection _activeShopSection;

        public void OpenSection(ShopSection shopSection)
        {
            _activeShopSection?.SetActive(false);
            _activeShopSection = shopSection;
            shopSection.SetActive(true);
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