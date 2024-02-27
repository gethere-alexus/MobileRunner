using Sources.Shop;

namespace Sources.Data
{
    public class ItemData
    {
        private readonly ScriptableObjects.ItemData _itemDataInformation;
        private readonly ItemStatus _itemStatus;

        public ItemData(ScriptableObjects.ItemData itemDataData, ItemStatus itemStatus)
        {
            _itemDataInformation = itemDataData;
            _itemStatus = itemStatus;
        }

        public ScriptableObjects.ItemData ItemDataInformation => _itemDataInformation;

        public ItemStatus ItemStatus => _itemStatus;
    }
}