using Infrastructure.Services.ServiceLocating;
using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 initialPosition);
        T[] LoadAll<T>(string path) where T : Object;
    }
}