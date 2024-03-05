using Sources.StaticData.CharacterTypes;
using UnityEngine;

namespace Sources.StaticData
{
    [CreateAssetMenu(fileName = "Skin",menuName = ("StaticData/Skin"))]
    public class SkinStaticData : ItemStaticData
    {
        public CharacterType Character;
    }
}
