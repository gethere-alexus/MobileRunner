using System;
using Sources.Player;

namespace Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Level { get; set; }
        public int CurrentXp { get; set; }
        public int RequiredXp { get; set; }
        public int Money { get; set; }
        public string SelectedSkin { get; set; }
        public string[] PurchasedSkins { get; set; }
        public Statistic[] PlayerStatistics { get; set; }

        public PlayerProgress()
        {
           
        }
        
    }
}