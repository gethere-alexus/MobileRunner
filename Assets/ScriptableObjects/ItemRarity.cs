using UnityEngine;

[CreateAssetMenu(fileName = "ItemRarity")]
public class ItemRarity : ScriptableObject
{
    [SerializeField] private string _rarityType;
    [SerializeField] private Sprite _itemFrame;
    [SerializeField] private ParticleSystem _rarityParticle;

    public string RarityType => _rarityType;
    public Sprite ItemFrame => _itemFrame;
    public ParticleSystem RarityParticle => _rarityParticle;
}
