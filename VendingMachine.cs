using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lab1_OOP
{
    internal class VendingMachine
    {
        private List<Tovar> _tovars;
        private Wallet _machinewallet;
        private Wallet _sessionwallet;
        public decimal Ballance => _sessionwallet.TotalBalance();
        public VendingMachine(List<Tovar> tovars, Wallet machineWallet)
        {
            _tovars = tovars;
            _machinewallet = machineWallet;
            _sessionwallet = new Wallet(0, 0, 0, 0, 0, 0);
        }
        public void ShowAllInfo()
        {
            Console.WriteLine("Меню товаров:");
            foreach (var tovar in _tovars) { Console.WriteLine(tovar.ShowInfo()); }
        }
        public void Insert500Yen()
        {
            _sessionwallet.AddCoin500Yen();
        }
        public void Insert100Yen()
        {
            _sessionwallet.AddCoin100Yen();
        }
        public void Insert50Yen()
        {
            _sessionwallet.AddCoin50Yen();
        }
        public void Insert10Yen()
        {
            _sessionwallet.AddCoin10Yen();
        }
        public void Insert5Yen()
        {
            _sessionwallet.AddCoin5Yen();
        }
        public void Insert1Yen()
        {
            _sessionwallet.AddCoin1Yen();
        }
        public Tovar FindTovar(int code)
        {
            foreach (var tovar in _tovars) 
            { 
                if (tovar.Code == code) return tovar; 
            } 
            return null;
        }
        private void GiveChangeToCustomer(Dictionary<decimal, int> changeCoins, Wallet _customerwallet)
        {
            foreach (var coin in changeCoins)
            {
                for (int i = 0; i < coin.Value; i++)
                {
                    switch (coin.Key)
                    {
                        case 500: 
                            _customerwallet.AddCoin500Yen(); 
                            break;
                        case 100: 
                            _customerwallet.AddCoin100Yen(); 
                            break;
                        case 50: 
                            _customerwallet.AddCoin50Yen(); 
                            break;
                        case 10: 
                            _customerwallet.AddCoin10Yen(); 
                            break;
                        case 5: 
                            _customerwallet.AddCoin5Yen(); 
                            break;
                        case 1: 
                            _customerwallet.AddCoin1Yen(); 
                            break;
                    }
                }
            }
        }
        public void CancelTransaction(Wallet _customerwallet)
        {
            for (int i = 0; i < _sessionwallet.Coin500Yen; i++)
                _customerwallet.AddCoin500Yen();
            for (int i = 0; i < _sessionwallet.Coin100Yen; i++)
                _customerwallet.AddCoin100Yen();
            for (int i = 0; i < _sessionwallet.Coin50Yen; i++)
                _customerwallet.AddCoin50Yen();
            for (int i = 0; i < _sessionwallet.Coin10Yen; i++)
                _customerwallet.AddCoin10Yen();
            for (int i = 0; i < _sessionwallet.Coin5Yen; i++)
                _customerwallet.AddCoin5Yen();
            for (int i = 0; i < _sessionwallet.Coin1Yen; i++)
                _customerwallet.AddCoin1Yen();

            decimal returnedAmount = _sessionwallet.TotalBalance();
            _sessionwallet.ClearBalance();
            Console.WriteLine($"\nВозвращено: {returnedAmount} Йен");
            Console.WriteLine("Текущий баланс вашего кошелька:");
            _customerwallet.BalanceInfo();
            Console.WriteLine();
        }
        public void RestockProduct(int productCode, int quantity)
        {
            Tovar product = FindTovar(productCode);
            if (product != null)
            {
                product.Quantity += quantity;
                Console.WriteLine($"Товар {product.Name} пополнен. {product.Quantity} шт.");
            }
            else
            {
                Console.WriteLine("Нет товара с таким кодом");
            }
        }
        private void RemoveChangeFromMachine(Dictionary<decimal, int> changeCoins)
        {
            foreach (var coin in changeCoins)
            {
                for (int i = 0; i < coin.Value; i++)
                {
                    switch (coin.Key)
                    {
                        case 500: 
                            _machinewallet.RemoveCoin500Yen(); 
                            break;
                        case 100: 
                            _machinewallet.RemoveCoin100Yen(); 
                            break;
                        case 50: 
                            _machinewallet.RemoveCoin50Yen(); 
                            break;
                        case 10: 
                            _machinewallet.RemoveCoin10Yen(); 
                            break;
                        case 5: 
                            _machinewallet.RemoveCoin5Yen(); 
                            break;
                        case 1: 
                            _machinewallet.RemoveCoin1Yen(); 
                            break;
                    }
                }
            }
        }
        private void TransferToMachineWallet()
        {
            for (int i = 0; i < _sessionwallet.Coin500Yen; i++)
                _machinewallet.AddCoin500Yen();
            for (int i = 0; i < _sessionwallet.Coin100Yen; i++)
                _machinewallet.AddCoin100Yen();
            for (int i = 0; i < _sessionwallet.Coin50Yen; i++)
                _machinewallet.AddCoin50Yen();
            for (int i = 0; i < _sessionwallet.Coin10Yen; i++)
                _machinewallet.AddCoin10Yen();
            for (int i = 0; i < _sessionwallet.Coin5Yen; i++)
                _machinewallet.AddCoin5Yen();
            for (int i = 0; i < _sessionwallet.Coin1Yen; i++)
                _machinewallet.AddCoin1Yen();
        }
        private string FormatChangeMessage(Dictionary<decimal, int> changeCoins, decimal changeAmount)
        {
            if (changeAmount == 0)
                return "Без сдачи.";

            List<string> messageParts = new List<string>();

            if (changeCoins.ContainsKey(500) && changeCoins[500] > 0)
                messageParts.Add($"{changeCoins[500]} монет(а/ы) 500 Йен");
            if (changeCoins.ContainsKey(100) && changeCoins[100] > 0)
                messageParts.Add($"{changeCoins[100]} монет(а/ы) 100 Йен");
            if (changeCoins.ContainsKey(50) && changeCoins[50] > 0)
                messageParts.Add($"{changeCoins[50]} монет(а/ы) 50 Йен");
            if (changeCoins.ContainsKey(10) && changeCoins[10] > 0)
                messageParts.Add($"{changeCoins[10]} монет(а/ы) 10 Йен");
            if (changeCoins.ContainsKey(5) && changeCoins[5] > 0)
                messageParts.Add($"{changeCoins[5]} монет(а/ы) 5 Йен");
            if (changeCoins.ContainsKey(1) && changeCoins[1] > 0)
                messageParts.Add($"{changeCoins[1]} монет(а/ы) 1 Йен");

            return $"Ваша сдача: {string.Join(", ", messageParts)}. Итого: {changeAmount} Йен";
        }
        public string PurchaseTovar(int tovarCode, Wallet customerWallet)
        {
            Tovar tovar = FindTovar(tovarCode);
            if (tovar == null)
                return "Нет товара с таким кодом";
            if (tovar.Quantity == 0)
                return "Выбранного вами товара нет в наличии";
            if (_sessionwallet.TotalBalance() < tovar.Price)
                return $"Недостаточно средств. Текущий баланс: { _sessionwallet.TotalBalance()}";
            decimal currentBalance = _sessionwallet.TotalBalance();
            decimal changeAmount = currentBalance - tovar.Price;
            Dictionary<decimal, int> changeCoins = _machinewallet.Change(changeAmount);
            GiveChangeToCustomer(changeCoins, customerWallet);
            RemoveChangeFromMachine(changeCoins);
            TransferToMachineWallet();
            _sessionwallet.ClearBalance();
            tovar.MinusTovar();
            string changeMessage = FormatChangeMessage(changeCoins, changeAmount);
            return $"Операция завершена. Спасибо за покупку {tovar.Name}! {changeMessage}";
        }
        public void MachineBalanceInfo()
        {
            Console.WriteLine("Касса автомата:");
            _machinewallet.BalanceInfo();
        }
        public void ClearMachineWallet()
        {
            decimal clearedAmount = _machinewallet.TotalBalance();
            _machinewallet.ClearBalance();
            Console.WriteLine($"\nКасса автомата очищена!\n");
        }
    }
}
