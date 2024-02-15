using Sources.Data;
using Sources.Shop;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sources.UI.ShopButtonView
{
    public abstract class UIShopButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        [Inject]
        public abstract void Construct(ItemData itemData, ItemShopDisplay itemShopDisplay);

        public void SetButtonText(string text)
        {
            _text.text = text;
        }
    }
}