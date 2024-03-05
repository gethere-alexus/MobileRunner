using System;

namespace Sources.Money
{
    public interface IWallet
    {
        event Action BalanceChanged;
        bool TrySpendMoney(int amountToSpend);
    }
}