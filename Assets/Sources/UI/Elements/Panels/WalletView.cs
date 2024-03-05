using Infrastructure.Data;
using Infrastructure.Services.DataProvider;
using Sources.Money;
using Sources.Utils;
using TMPro;
using UnityEngine;

namespace Sources.UI.Elements.Panels
{
    public class WalletView : MonoBehaviour, IDataWriter
    {
        [SerializeField] private TMP_Text _moneyText;
        private Wallet _walletInstance;
        private void Awake()
        {
            _walletInstance = new Wallet();
            _walletInstance.BalanceChanged += UpdateView;
        }

        private void UpdateView() => 
            _moneyText.text = TextFormatter.DivideIntWithChar(_walletInstance.Balance, ',');

        public void UpdateData() => 
            _walletInstance.UpdateData();

        public void LoadData(PlayerProgress progress) => 
            _walletInstance.LoadData(progress);

        public Wallet WalletInstance => 
            _walletInstance;
    }
}
