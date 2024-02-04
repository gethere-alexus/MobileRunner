using Data_Scripts;
using Shop_Scripts;
using UI_Scripts.ShopButtonView;
using UnityEngine.UI;

public class UISelectButton : UIShopButtonView
{
    public override void Construct(ItemData itemData, ItemShopDisplay itemShopDisplay)
    {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(itemShopDisplay.SelectPreviewedSkin);
        SetButtonText("Select");
    }
}
