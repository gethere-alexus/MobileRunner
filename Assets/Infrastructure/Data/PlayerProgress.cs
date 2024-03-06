using System;
using Sources.Player;
using Sources.StaticData.CharacterTypes;

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
        public StatisticData[] StatValues; //health,damage,critical damage, etc
    }
}