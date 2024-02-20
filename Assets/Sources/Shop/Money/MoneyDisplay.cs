using TMPro;
using UnityEngine;

namespace Sources.Shop.Money
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceDisplay;

        private Wallet _walletInstance;

        private void Awake()
        {
            _walletInstance = new Wallet();
            
            UpdateBalanceDisplay();
        }

        private void OnEnable()
        {
            _walletInstance.OnMoneySpendSucceeded += UpdateBalanceDisplay;
        }

        private void OnDisable()
        {
            _walletInstance.OnMoneySpendSucceeded -= UpdateBalanceDisplay;
        }

        private void UpdateBalanceDisplay() =>
            _balanceDisplay.text = Utils.TextFormatter
                .DivideIntWithChar(_walletInstance.Balance, ',');
    }
}