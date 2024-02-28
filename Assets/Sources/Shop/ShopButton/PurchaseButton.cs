using Sources.Data;
using Sources.Utils;
using TMPro;
using UnityEngine;

namespace Sources.Shop.ShopButton
{
    public class PurchaseButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _price;
        
        public void Construct(ItemData itemData)
        {
            _price.text = TextFormatter.DivideIntWithChar(itemData.ItemStaticDataInformation.Price, ',');
        }
    }
}