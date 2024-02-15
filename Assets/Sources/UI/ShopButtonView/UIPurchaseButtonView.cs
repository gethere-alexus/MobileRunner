using Sources.Data;
using Sources.Shop;
using Sources.Utils;
using UnityEngine.UI;

namespace Sources.UI.ShopButtonView
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