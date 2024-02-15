using Sources.Data;
using Sources.Shop;
using UnityEngine.UI;

namespace Sources.UI.ShopButtonView
{
    public class UISelectButton : UIShopButtonView
    {
        public override void Construct(ItemData itemData, ItemShopDisplay itemShopDisplay)
        {
            Button btn = this.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(itemShopDisplay.SelectPreviewedSkin);
            SetButtonText("Select");
        }
    }
}