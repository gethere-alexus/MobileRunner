using Sources.Shop;
using Sources.StaticData;

namespace Sources.Data
{
    public class ItemData<TItem> where TItem : ItemStaticData
    {
        public TItem ItemInformation { get; }
        public ItemStatus ItemStatus { get; }

        public ItemData(TItem itemData, ItemStatus itemStatus)
        {
            ItemInformation = itemData;
            ItemStatus = itemStatus;
        }
    }
}