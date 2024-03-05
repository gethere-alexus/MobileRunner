using System;
using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.ServiceLocating;

namespace Sources.Money
{
    public class Wallet : IDataWriter, IWallet
    {
        private int _balance = 0;
        public event Action BalanceChanged;

        public bool TrySpendMoney(int amountToSpend)
        {
            bool isSucceeded = false;
            if (_balance - amountToSpend >= 0)
            {
                _balance -= amountToSpend;
                isSucceeded = true;
                BalanceChanged?.Invoke();
                UpdateData();
            }

            return isSucceeded;
        }
        public void LoadData(PlayerProgress progress)
        {
            _balance = progress.Money;
            BalanceChanged?.Invoke();
        }

        public void UpdateData()
        {
            IProgressProvider progressProvider = ServiceLocator.Container.Single<IProgressProvider>();
            
            PlayerProgress progressCopy = progressProvider.GetProgress();
            progressCopy.Money = _balance;
            
            progressProvider.UpdateData(progressCopy);
        }

        public int Balance => 
            _balance;
    }
}