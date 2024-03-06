using UnityEngine;

namespace Sources.StaticData
{
    [CreateAssetMenu(menuName = ("DataContainers/StatisticDescription"))]
    public class StatisticDescription : ScriptableObject
    {
        public StatisticType Statistic;
        public Sprite BoostSprite;
    }
}