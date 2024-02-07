using Data_Scripts;
using Shop_Scripts;
using UnityEngine.UI;

namespace UI_Scripts.ShopButtonView
{
    public class UIPurchaseButtonView : UIShopButtonView
    {
        public override void Construct(ItemData itemData, ItemShopDisplay itemShopDisplay)
        {
            Button btn = this.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(itemShopDisplay.PurchasePreviewedSkin);
            SetButtonText(TextFormatter.DivideIntWithChar(itemData.ItemInformation.Price, ','));
        }
    }
}
