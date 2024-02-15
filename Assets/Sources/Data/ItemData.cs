using Sources.ScriptableObjects;
using Sources.Shop;

namespace Sources.Data
{
    public class ItemData
    {
        private readonly ItemDataContainer _itemInformation;
        private readonly ItemStatus _itemStatus;

        public ItemData(ItemDataContainer itemData, ItemStatus itemStatus)
        {
            _itemInformation = itemData;
            _itemStatus = itemStatus;
        }

        public ItemDataContainer ItemInformation => _itemInformation;

        public ItemStatus ItemStatus => _itemStatus;
    }
}