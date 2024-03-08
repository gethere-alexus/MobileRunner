using Sources.StaticData.CharacterTypes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.StaticData
{
    [CreateAssetMenu(fileName = "Skin",menuName = ("StaticData/Skin"))]
    public class SkinStaticData : ItemStaticData
    {
        [FormerlySerializedAs("Gun")] public CharacterType Character;
    }
}
