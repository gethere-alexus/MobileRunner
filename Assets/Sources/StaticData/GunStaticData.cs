using Sources.StaticData.GunTypes;
using UnityEngine;

namespace Sources.StaticData
{
    [CreateAssetMenu(fileName = "Character",menuName = ("StaticData/Character"))]
    public class GunStaticData : ItemStaticData
    {
        public GunType Gun;
    }
}