using System;
using Sources.Player;
using Sources.StaticData.CharacterTypes;

namespace Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Level { get; set; }
        public int CurrentXp { get; set; }
        public int RequiredXp { get; set; }
        public int Money { get; set; }
        public CharacterType SelectedSkin { get; set; }
        public CharacterType[] PurchasedSkins { get; set; }
        public Statistic[] PlayerStatistics { get; set; }

        public PlayerProgress()
        {
           
        }
        
    }
}