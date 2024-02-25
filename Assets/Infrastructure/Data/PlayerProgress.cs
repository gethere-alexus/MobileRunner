using System;
using Infrastructure.Services.DataProvider;

namespace Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Money { get; set; } 

        public PlayerProgress(int money = 0)
        {
            Money = money;
        }
    }
}