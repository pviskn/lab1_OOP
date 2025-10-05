using System;

namespace lab1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tovar> tovars = new List<Tovar>
            {
                new Tovar(1, "Pocari Sweat Water", 150, 20),
                new Tovar(2, "Water Evian", 110, 20),
                new Tovar(3, "Banana Milk", 130, 10),
                new Tovar(4, "Premium Boss Black Coffee", 140, 30),
                new Tovar(5, "Monster energy drink", 210, 10),
                new Tovar(6, "Coca Cola", 120, 10),
                new Tovar(7, "Green Lemonade", 160, 10),
                new Tovar(8, "Orange juice", 150, 15),
                new Tovar(9, "Matcha drink", 100, 20),
                new Tovar(10, "Teas Tea", 100, 40),
            };
            Wallet _machinewallet = new Wallet(35, 50, 75, 110, 80, 500);
            Wallet _customerwallet = new Wallet(3, 10, 15, 20, 5, 30);
            VendingMachine machine = new VendingMachine(tovars, _machinewallet);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n1. Посмотреть товары");
                Console.WriteLine("2. Внести монеты");
                Console.WriteLine("3. Купить товар");
                Console.WriteLine("4. Вернуть деньги");
                Console.WriteLine("5. Режим администратора");
                Console.WriteLine("0. Выход\n");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        machine.ShowAllInfo();
                        break;

                    case "2":
                        InsertCoinsMenu(machine, _customerwallet);
                        break;

                    case "3":
                        BuyTovar(machine, _customerwallet);
                        break;

                    case "4":
                        machine.CancelTransaction(_customerwallet);
                        break;

                    case "5":
                        AdminMenu(machine);
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("До свидания!");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        static void InsertCoinsMenu(VendingMachine machine, Wallet _customerwallet)
        {
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("Ваш кошелек:");
                _customerwallet.BalanceInfo();
                Console.WriteLine($"\nВ автомате: {machine.Ballance} Йен");
                Console.WriteLine("\n1. Внести 500 Йен");
                Console.WriteLine("2. Внести 100 Йен");
                Console.WriteLine("3. Внести 50 Йен");
                Console.WriteLine("4. Внести 10 Йен");
                Console.WriteLine("5. Внести 5 Йен");
                Console.WriteLine("6. Внести 1 Йену");
                Console.WriteLine("0. Назад в главное меню\n");
                Console.Write("Выберите монету: ");

                string coinChoice = Console.ReadLine();

                switch (coinChoice)
                {
                    case "1":
                        if (_customerwallet.Coin500Yen > 0)
                        {
                            _customerwallet.RemoveCoin500Yen();
                            machine.Insert500Yen();
                            Console.WriteLine("Внесена монета 500 Йен");
                        }
                        else
                            Console.WriteLine("Отсутствует монета данного номинала");
                        break;
                    case "2":
                        if (_customerwallet.Coin100Yen > 0)
                        {
                            _customerwallet.RemoveCoin100Yen();
                            machine.Insert100Yen();
                            Console.WriteLine("Внесена монета 100 Йен");
                        }
                        else
                            Console.WriteLine("Отсутствует монета данного номинала");
                        break;
                    case "3":
                        if (_customerwallet.Coin50Yen > 0)
                        {
                            _customerwallet.RemoveCoin50Yen();
                            machine.Insert50Yen();
                            Console.WriteLine("Внесена монета 50 Йен");
                        }
                        else
                            Console.WriteLine("Отсутствует монета данного номинала");
                        break;
                    case "4":
                        if (_customerwallet.Coin10Yen > 0)
                        {
                            _customerwallet.RemoveCoin10Yen();
                            machine.Insert10Yen();
                            Console.WriteLine("Внесена монета 10 Йен");
                        }
                        else
                            Console.WriteLine("Отсутствует монета данного номинала");
                        break;
                    case "5":
                        if (_customerwallet.Coin5Yen > 0)
                        {
                            _customerwallet.RemoveCoin5Yen();
                            machine.Insert5Yen();
                            Console.WriteLine("Внесена монета 5 Йен");
                        }
                        else
                            Console.WriteLine("Отсутствует монета данного номинала");
                        break;
                    case "6":
                        if (_customerwallet.Coin1Yen > 0)
                        {
                            _customerwallet.RemoveCoin1Yen();
                            machine.Insert1Yen();
                            Console.WriteLine("Внесена монета 1 Йена");
                        }
                        else
                            Console.WriteLine("Отсутствует монета данного номинала");
                        break;
                    case "0":
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }

                if (coinChoice != "0")
                {
                    Console.WriteLine($"\nТекущий баланс в автомате: {machine.Ballance} Йен");
                }
            }
        }

        static void BuyTovar(VendingMachine machine, Wallet customerWallet)
        {
            Console.WriteLine();
            machine.ShowAllInfo();
            Console.Write("\nВведите код товара для покупки: ");

            if (int.TryParse(Console.ReadLine(), out int code))
            {
                string result = machine.PurchaseTovar(code, customerWallet);
                Console.WriteLine($"\n{result}");
                Console.WriteLine("\nВаш кошелек после покупки:");
                customerWallet.BalanceInfo();
            }
            else
            {
                Console.WriteLine("Нет товара с таким кодом");
            }
        }

        static void AdminMenu(VendingMachine machine)
        {
            string adminPassword = "1234";

            Console.Write("\nВведите пароль администратора: ");
            string inputPassword = Console.ReadLine();

            if (inputPassword != adminPassword)
            {
                Console.WriteLine("Неверный пароль!");
                return;
            }

            Console.WriteLine("Доступ разрешен");

            bool inAdminMenu = true;

            while (inAdminMenu)
            {
                Console.WriteLine("\nРЕЖИМ АДМИНИСТРАТОРА");
                Console.WriteLine("1. Посмотреть все товары");
                Console.WriteLine("2. Пополнить товар");
                Console.WriteLine("3. Посмотреть кассу автомата");
                Console.WriteLine("4. Забрать деньги");
                Console.WriteLine("0. Выйти из режима администратора\n");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        machine.ShowAllInfo();
                        break;

                    case "2":
                        Console.Write("Введите код товара для пополнения: ");
                        if (int.TryParse(Console.ReadLine(), out int code))
                        {
                            Console.Write("Введите количество для добавления: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                            {
                                machine.RestockProduct(code, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Неверное количество");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный код товара");
                        }
                        break;

                    case "3":
                        Console.WriteLine();
                        machine.MachineBalanceInfo();
                        break;

                    case "4":
                        machine.ClearMachineWallet();
                        break;

                    case "0":
                        inAdminMenu = false;
                        Console.WriteLine("Выход из режима администратора...");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }
    }
}