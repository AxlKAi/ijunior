using System;
using System.Collections.Generic;
using System.Globalization;

namespace _6_6_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();

            application.Run();
        }
    }

    class Application
    {
        const string ShowAllSellerGoodsCommand = "1";
        const string BuyItemCommand = "2";
        const string ShowBuyerInventoryCommand = "3";
        const string ReturnItemToSellerCommand = "4";
        const string ShowAllFavouriteCommand = "5";
        const string AddToFovouriteCommand = "6";
        const string BuyAllFavouritesCommand = "7";
        const string ResetFavouritesCommand = "8";
        const string RenewAllSellerGoodsCommand = "9";
        const string ExitCommand = "0";
        const string NegativeAnswer = "n";

        public void Run()
        {
            Seller seller = new Seller("Продавец", 10000, 1.3f);
            Buyer buyer = new Buyer("Покупатель", 1000, .5f);

            bool isEnd = false;

            while (isEnd == false)
            {
                ShowMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllSellerGoodsCommand:
                        seller.ShowAllInventory();
                        break;

                    case BuyItemCommand:
                        MakeDeal(buyer, seller);
                        break;

                    case ShowBuyerInventoryCommand:
                        buyer.ShowAllInventory();
                        break;

                    case ReturnItemToSellerCommand:
                        MakeDeal(seller, buyer);
                        break;

                    case ShowAllFavouriteCommand:
                        buyer.ShowAllFavourites();
                        break;

                    case AddToFovouriteCommand:
                        AddToFavourite(buyer, seller);
                        break;

                    case BuyAllFavouritesCommand:
                        seller.SellAllFavourites(buyer);
                        break;

                    case ResetFavouritesCommand:
                        buyer.ResetFavourites();
                        break;

                    case RenewAllSellerGoodsCommand:
                        seller.RenewGoods();
                        break;

                    case ExitCommand:
                        isEnd = TryUserWantExit();
                        break;
                }

                WaitToPressKey();
            }
        }

        private void MakeDeal(Trader buyer, Trader seller)
        {
            int itemIndex;
            string userInput;

            Console.WriteLine($"Выберите что {buyer.Name} хочет купить у {seller.Name}.");
            seller.ShowAllInventory();
            Console.WriteLine("Введите индекс товара");
            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out itemIndex))
            {
                seller.Sell(buyer, itemIndex);
            }
            else
            {
                Console.WriteLine($"Не могу распознать цифровой ввод.");
            }
        }

        private void AddToFavourite(Buyer buyer, Trader seller)
        {
            int itemIndex;
            string userInput;

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Добавьте товар в избранное.");
            Console.WriteLine($"Список товаров продавца.");
            seller.ShowAllInventory();

            Console.WriteLine($"Выберите что добавить в избранное.");
            Console.WriteLine("Введите индекс товара:");
            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out itemIndex))
            {
                buyer.AddToFavourite(seller.GetItemName(itemIndex));
            }
            else
            {
                Console.WriteLine($"Не могу распознать цифровой ввод.");
            }
        }

        private void ShowMainMenu()
        {
            string showAllSellerGoodsMessage = "Показать все товары продовца.";
            string buyItemMessage = "Купить товар.";
            string showBuyerInventoryMessage = "Показать инвентарь покупателя.";
            string returnItemToSellerMessage = "Продать товар покупателя продавцу.";
            string showAllFavouriteMessage = "Показать избранное.";
            string addToFovouriteMessage = "Добавить товар в желаемые покупки.";
            string buyAllFavouritesMessage = "Купить все товары из списка покупок.";
            string resetFavouritesMessage = "Сбросить список избранного.";
            string renewAllSellerGoodsMessage = "Обновить товар у продавца.";
            string exitMenuText = "Выход.";

            Console.Clear();
            Console.WriteLine($"{ShowAllSellerGoodsCommand}. {showAllSellerGoodsMessage}");
            Console.WriteLine($"{BuyItemCommand}. {buyItemMessage}");
            Console.WriteLine($"{ShowBuyerInventoryCommand}. {showBuyerInventoryMessage}");
            Console.WriteLine($"{ReturnItemToSellerCommand}. {returnItemToSellerMessage}");
            Console.WriteLine($"{ShowAllFavouriteCommand}. {showAllFavouriteMessage}");
            Console.WriteLine($"{AddToFovouriteCommand}. {addToFovouriteMessage}");
            Console.WriteLine($"{BuyAllFavouritesCommand}. {buyAllFavouritesMessage}");
            Console.WriteLine($"{ResetFavouritesCommand}. {resetFavouritesMessage}");
            Console.WriteLine($"{RenewAllSellerGoodsCommand}. {renewAllSellerGoodsMessage}");
            Console.WriteLine($"{ExitCommand}. {exitMenuText}");
            Console.WriteLine();
        }

        private bool TryUserWantExit()
        {
            string userInput;
            Console.Write($"Вы хотите выйти? ({NegativeAnswer} - нет, другой - да):");
            userInput = Console.ReadLine();

            if (userInput == NegativeAnswer)
            {
                return false;
            }
            else
            {
                Console.WriteLine("До свиданья....");
                return true;
            }
        }

        private void WaitToPressKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.....");
            Console.ReadKey();
        }
    }

    class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public int Price { get; private set; }
        public string Name { get; private set; }
    }

    class Seller : Trader
    {
        public Seller(string name, int money, float sellingCoefficient) : base(name, money, sellingCoefficient)
        {
            RenewGoods();
        }

        public void SellProductByName(Trader buyer, string productName)
        {
            int itemIndex = FindIndexByName(productName);

            if (itemIndex >= 0)
            {
                Sell(buyer, itemIndex);
            }
        }

        public void RenewGoods()
        {
            Items = new List<Item>()
            {
                new Item("Карандаш", 10),
                new Item("Ручка", 15),
                new Item("Ластик", 7),
                new Item("Блокнот", 20),
                new Item("Расскраски", 8),
                new Item("Пенал", 12),
                new Item("Карандашница", 14),
                new Item("Картон", 7),
            };

            Console.WriteLine($"Обновление списка товаров у {Name}.");
        }

        public void SellAllFavourites(Buyer buyer)
        {
            foreach (string productName in buyer.Favourites)
                SellProductByName(buyer, productName);

            buyer.ResetFavourites();
        }

        private int FindIndexByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == name)
                    return i;
            }

            return -1;
        }
    }

    class Buyer : Trader
    {
        private List<string> _favourites = new List<string>();

        public Buyer(string name, int money, float sellingCoefficient) : base(name, money, sellingCoefficient) { }

        public IReadOnlyList<string> Favourites => _favourites;

        public void ShowAllFavourites()
        {
            Console.WriteLine($"Избранное покупателя \"{Name}\"  -: Счет: {Money} денег :-");

            for (int i = 0; i < _favourites.Count; i++)
            {
                Console.WriteLine($"[{i}] {_favourites[i]} ");
            }

            Console.WriteLine();
        }

        public void AddToFavourite(string itemName)
        {
            if (_favourites.Contains(itemName))
            {
                Console.WriteLine($"В избранном уже содержится товар {itemName}.");
            }
            else
            {
                Console.WriteLine($"Добавляю в избранное товар {itemName}.");
                _favourites.Add(itemName);
            }
        }

        public void ResetFavourites()
        {
            Console.WriteLine("Очищаю список избранного.");
            _favourites = new List<string>();
        }
    }

    abstract class Trader
    {
        protected List<Item> Items = new List<Item>();

        private float _sellingCoefficient = 1.3f;
        private CultureInfo _cultureInfoRu = new CultureInfo("ru-RU");

        public Trader(string name, int money, float sellingCoefficient)
        {
            Name = name;
            Money = money;
            _sellingCoefficient = sellingCoefficient;
        }

        public string Name { get; private set; }

        public float Money { get; private set; }

        public void Sell(Trader buyer, int sellingItemIndex)
        {
            if (sellingItemIndex < 0 || sellingItemIndex >= Items.Count)
            {
                Console.WriteLine($"Указанный индекс {sellingItemIndex}" +
                    $" не попадает в границы массива.");
                return;
            }

            Item sellingItem = Items[sellingItemIndex];
            float sellingPrice = sellingItem.Price * _sellingCoefficient;

            Console.WriteLine($"Продается {sellingItem.Name} за {sellingPrice} денег.");

            if (buyer.Money >= sellingPrice)
            {
                buyer.TakeMoney(sellingPrice);
                buyer.PutInInventory(sellingItem);
                Items.Remove(sellingItem);
                GiveMoney(sellingPrice);
            }
            else
            {
                Console.WriteLine($"У покупателя не достаточно денег. " +
                    $"Товар стоит {sellingItem.Price} а в наличие только {buyer.Money}"); ;
            }
        }

        public string GetItemName(int index)
        {
            if (index < 0 || index >= Items.Count)
            {
                Console.WriteLine($"Указанный индекс {index}" +
                    $" не попадает в границы массива.");
                return "";
            }

            return Items[index].Name;
        }

        public void ShowAllInventory()
        {
            Console.WriteLine($"Инвентарь \"\"{Name}  Счет: {Money} денег.");

            for (int i = 0; i < Items.Count; i++)
            {
                var sellingPrice = Items[i].Price * _sellingCoefficient;
                Console.WriteLine($"[{i}] {Items[i].Name} цена: {sellingPrice.ToString("C", _cultureInfoRu)}");
            }

            Console.WriteLine();
        }

        private void PutInInventory(Item item)
        {
            Items.Add(item);
        }

        private void TakeMoney(float value)
        { 
            Money -= value;
        }

        private void GiveMoney(float money)
        {
            Money += money;
        }
    }
}
