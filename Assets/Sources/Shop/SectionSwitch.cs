using UnityEngine;

namespace Sources.Shop
{
    public class SectionSwitch : MonoBehaviour
    {
        [SerializeField] private ShopSection[] _sections;
        [SerializeField] private int _startSectionIndex;
        private ShopSection _activeShopSection;

        private void Awake()
        {
            foreach (var section in _sections)
            {
                section.SelectionButton.onClick.AddListener(() => OpenSection(section));
            }

            OpenSection(_sections[_startSectionIndex]);
        }

        private void OpenSection(ShopSection shopSection)
        {
            _activeShopSection?.SetActive(false);
            _activeShopSection = shopSection;
            shopSection.SetActive(true);
        }
    }
}