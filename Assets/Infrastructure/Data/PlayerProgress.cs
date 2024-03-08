using System;
using Sources.Player;
using Sources.StaticData.CharacterTypes;
using Sources.StaticData.GunTypes;
using UnityEngine.Serialization;

namespace Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Level;
        public int CurrentXp;
        public int RequiredXp;
        public int Money;
        public CharacterType SelectedSkin;
        public CharacterType[] PurchasedSkins;
        public GunType SelectedGun;
        public GunType[] PurchasedGuns;
        public StatisticData[] StatValues; //health,damage,critical damage, etc
    }
}