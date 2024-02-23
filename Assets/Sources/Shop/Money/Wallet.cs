using System;
using Infrastructure.PlayerData;
using Infrastructure.Services.ServiceLocating;

namespace Sources.Shop.Money
{
    public class Wallet
    {
        private int _balance;

        public event Action OnMoneySpendSucceeded, OnMoneySpendFailed;

        public Wallet(int initialBalance = 0)
        {
            _balance = ServiceLocator.Container.Single<IProgressProvider>().Money;
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
    }
}