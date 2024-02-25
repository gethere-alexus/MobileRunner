using System;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;

namespace Sources.Shop.Money
{
    public class Wallet : IDataWriter
    {
        private int _balance;

        public event Action OnMoneySpendSucceeded, OnMoneySpendFailed;

        public Wallet(int initialBalance = 0)
        {
            _balance = ServiceLocator.Container.Single<IProgressProvider>().PlayerProgressData.Money;
        }
        
        public void TrySpend(int amountToSpend)
        {
            if (_balance - amountToSpend >= 0)
            {
                _balance -= amountToSpend;

                OnMoneySpendSucceeded?.Invoke();
            }
            else
            {
                OnMoneySpendFailed?.Invoke();
            }
        }

        public void TrySpend(int amountToSpend, out bool operationResult)
        {
            if (_balance - amountToSpend >= 0)
            {
                _balance -= amountToSpend;
                operationResult = true;

                OnMoneySpendSucceeded?.Invoke();
            }
            else
            {
                OnMoneySpendFailed?.Invoke();
                operationResult = false;
            }
        }


        public int Balance => _balance;
        public void Load(PlayerProgress progress)
        {
        }

        public void Update(PlayerProgress progress)
        {
            throw new NotImplementedException();
        }
    }
}