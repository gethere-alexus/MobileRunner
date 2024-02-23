using Sources.ScriptableObjects;
using Sources.Shop;

namespace Sources.Data
{
    public class ItemData
    {
        private readonly Item _itemInformation;
        private readonly ItemStatus _itemStatus;

        public ItemData(Item itemData, ItemStatus itemStatus)
        {
            _itemInformation = itemData;
            _itemStatus = itemStatus;
        }

        public Item ItemInformation => _itemInformation;

        public ItemStatus ItemStatus => _itemStatus;
    }
}