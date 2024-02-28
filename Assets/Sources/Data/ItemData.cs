using Sources.ScriptableObjects;
using Sources.Shop;

namespace Sources.Data
{
    public class ItemData
    {
        private readonly ItemStaticData _itemStaticDataInformation;
        private readonly ItemStatus _itemStatus;

        public ItemData(ScriptableObjects.ItemStaticData itemStaticDataData, ItemStatus itemStatus)
        {
            _itemStaticDataInformation = itemStaticDataData;
            _itemStatus = itemStatus;
        }

        public ScriptableObjects.ItemStaticData ItemStaticDataInformation => _itemStaticDataInformation;

        public ItemStatus ItemStatus => _itemStatus;
    }
}