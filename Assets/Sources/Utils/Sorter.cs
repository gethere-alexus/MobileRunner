using Sources.ScriptableObjects;

namespace Sources.Utils
{
    public static class Sorter
    {
        public static TItems[] SortItemsByPrice<TItems>(TItems[] partArrayToSort) where TItems : ItemDataContainer
        {
            TItems[] toReturn = partArrayToSort;

            TItems temp;

            // used bubble sort algorithm - https://www.geeksforgeeks.org/bubble-sort/
            for (int i = 0; i < toReturn.Length - 1; i++)
            {
                bool isSwapped = false;
                for (int j = 0; j < toReturn.Length - i - 1; j++)
                {
                    if (toReturn[j].Price > toReturn[j + 1].Price)
                    {
                        temp = toReturn[j];
                        toReturn[j] = toReturn[j + 1];
                        toReturn[j + 1] = temp;

                        isSwapped = true;
                    }
                }

                if (isSwapped == false)
                    break;
            }

            return toReturn;
        }
    }
}