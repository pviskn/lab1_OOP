using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_OOP
{
    internal class Wallet
    {
        public int Coin500Yen { get; private set; }
        public int Coin100Yen { get; private set; }
        public int Coin50Yen { get; private set; }
        public int Coin10Yen { get; private set; }
        public int Coin5Yen { get; private set; }
        public int Coin1Yen { get; private set; }
        public Wallet(int coin500Yen, int coin100Yen, int coin50Yen, int coin10Yen, int coin5Yen, int coin1Yen)
        {
            Coin500Yen = coin500Yen;
            Coin100Yen = coin100Yen;
            Coin50Yen = coin50Yen;
            Coin10Yen = coin10Yen;
            Coin5Yen = coin5Yen;
            Coin1Yen = coin1Yen;
        }
        public void AddCoin500Yen() { Coin500Yen++; }
        public void AddCoin100Yen() { Coin100Yen++; }
        public void AddCoin50Yen() { Coin50Yen++; }
        public void AddCoin10Yen() { Coin10Yen++; }
        public void AddCoin5Yen() { Coin5Yen++; }
        public void AddCoin1Yen() { Coin1Yen++; }
        public void RemoveCoin500Yen() { Coin500Yen--; }
        public void RemoveCoin100Yen() { Coin100Yen--; }
        public void RemoveCoin50Yen() { Coin50Yen--; }
        public void RemoveCoin10Yen() { Coin10Yen--; }
        public void RemoveCoin5Yen() { Coin5Yen--; }
        public void RemoveCoin1Yen() { Coin1Yen--; }
        public decimal TotalBalance()
        { return Coin500Yen * 500 + Coin100Yen * 100 + Coin50Yen * 50 + Coin10Yen * 10 + Coin5Yen * 5 +  Coin1Yen; }
        public void BalanceInfo()
        {
            Console.WriteLine("В кошельке:");
            if (Coin500Yen > 0)
                Console.WriteLine(Coin500Yen + " монет(ы) номиналом 500 Йен");
            if (Coin100Yen > 0)
                Console.WriteLine(Coin100Yen + " монет(ы) номиналом 100 Йен");
            if (Coin50Yen > 0)
                Console.WriteLine(Coin50Yen + " монет(ы) номиналом 50 Йен");
            if (Coin10Yen > 0)
                Console.WriteLine(Coin10Yen + " монет(ы) номиналом 10 Йен");
            if (Coin5Yen > 0)
                Console.WriteLine(Coin5Yen + " монет(ы) номиналом 5 Йен");
            if (Coin1Yen > 0)
                Console.WriteLine(Coin1Yen + " монет(ы) номиналом 1 Йен");
            Console.WriteLine($"Итого {TotalBalance()} Йен");
        }
        public void ClearBalance()
        {
            Coin500Yen = 0;
            Coin100Yen = 0;
            Coin50Yen = 0;
            Coin10Yen = 0;
            Coin5Yen = 0;
            Coin1Yen = 0;
        }
        public Dictionary<decimal, int> Change(decimal amount)
        {
            var _change = new Dictionary<decimal, int>();
            decimal payback = amount;
            do
            {
                int coins500 = (int)(payback / 500);
                if (coins500 > 0 && Coin500Yen >= coins500)
                {
                    _change.Add(500, coins500);
                    payback -= coins500 * 500;
                }
                else if (coins500 > 0 && Coin500Yen < coins500 && Coin500Yen != 0)
                {
                    _change.Add(500, Coin500Yen);
                    payback -= Coin500Yen * 500;
                }
                int coins100 = (int)(payback / 100);
                if (coins100 > 0 && Coin100Yen >= coins100)
                {
                    _change.Add(100, coins100);
                    payback -= coins100 * 100;
                }
                else if (coins100 > 0 && Coin100Yen >= coins100 && Coin100Yen != 0)
                {
                    _change.Add(100, Coin100Yen);
                    payback -= Coin100Yen * 100;
                }
                int coins50 = (int)(payback / 50);
                if (coins50 > 0 && Coin50Yen >= coins50)
                {
                    _change.Add(50, coins50);
                    payback -= coins50 * 50;
                }
                else if (coins50 > 0 && Coin50Yen < coins50 && Coin50Yen != 0)
                {
                    _change.Add(50, Coin50Yen);
                    payback -= Coin50Yen * 50;
                }
                int coins10 = (int)(payback / 10);
                if (coins10 > 0 && Coin10Yen >= coins10)
                {
                    _change.Add(10, coins10);
                    payback -= coins10 * 10;
                }
                else if (coins10 > 0 && Coin10Yen < coins10 && Coin10Yen != 0)
                {
                    _change.Add(10, Coin10Yen);
                    payback -= Coin10Yen * 10;
                }
                int coins5 = (int)(payback / 5);
                if (coins5 > 0 && Coin5Yen >= coins5)
                {
                    _change.Add(5, coins5);
                    payback -= coins5 * 5;
                }
                else if (coins5 > 0 && Coin5Yen < coins5 && Coin5Yen != 0)
                {
                    _change.Add(5, Coin5Yen);
                    payback -= Coin5Yen * 5;
                }
                int coins1 = (int)payback;
                if (coins1 > 0 && Coin1Yen >= coins1)
                {
                    _change.Add(1, coins1);
                    payback -= coins1 * 1;
                }
                else if (coins1 > 0 && Coin1Yen < coins1 && Coin1Yen != 0)
                {
                    _change.Add(1, Coin1Yen);
                    payback -= Coin1Yen * 1;
                }
            }
            while (payback > 0);
            return _change;
        }
    }
}
