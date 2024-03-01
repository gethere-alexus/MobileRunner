using System.Collections.Generic;
using Sources.ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Services.DataProvider
{
    public static class DataExtensions
    {
        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static string[] ToSerializableArray(this IEnumerable<ItemStaticData> items)
        {
            List<string> toReturn = new();
            
            foreach (ItemStaticData item in items)
            {
                toReturn.Add(item.ToSerializable());
            }

            return toReturn.ToArray();
        }

        public static string ToSerializable(this ItemStaticData item) => 
            item.Name;
    }
}