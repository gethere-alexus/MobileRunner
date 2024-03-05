using System.Collections.Generic;
using Sources.StaticData;
using Sources.StaticData.CharacterTypes;
using UnityEngine;

namespace Infrastructure.Services.DataProvider
{
    public static class DataExtensions
    {
        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static CharacterType[] ToSerializableArray(this IEnumerable<SkinStaticData> items)
        {
            List<CharacterType> toReturn = new();
            
            foreach (SkinStaticData item in items)
            {
                toReturn.Add(item.ToSerializable());
            }

            return toReturn.ToArray();
        }

        public static CharacterType ToSerializable(this SkinStaticData item) => 
            item.Character;
    }
}