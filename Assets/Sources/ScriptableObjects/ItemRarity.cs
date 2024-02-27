using UnityEngine;

namespace Sources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemRarity")]
    public class ItemRarity : ScriptableObject
    {
        public string RarityType;
        public Sprite ItemFrame;
        public ParticleSystem RarityParticle;
    }
}