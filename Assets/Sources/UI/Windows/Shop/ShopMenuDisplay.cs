using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop
{
    public class ShopMenuDisplay : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        public void InstantiateShopMenu() =>
            Instantiate(this);

        private void Awake()
        {
            _closeButton.onClick.AddListener(DestroyShopMenu);
        }

        private void DestroyShopMenu()
        {
            Destroy(this.gameObject);
        }
    }
}