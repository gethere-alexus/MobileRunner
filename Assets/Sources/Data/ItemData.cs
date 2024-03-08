using Sources.Shop;
using Sources.StaticData;

namespace Sources.Data
{
    public class ItemData
    {
        public ItemStaticData ItemInformation { get; }
        public ItemStatus ItemStatus { get; }

        public ItemData(ItemStaticData itemData, ItemStatus itemStatus)
        {
            ItemInformation = itemData;
            ItemStatus = itemStatus;
        }
    }
}