using UnityEngine;

namespace Infrastructure.Services.DataProvider
{
    public static class DataExtensions
    {
        public static T ToDeserialized<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
    }
}