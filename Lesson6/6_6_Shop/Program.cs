using System;
using System.Collections.Generic;
using System.Globalization;
/* 
 * Существует продавец, он имеет у себя список товаров, 
 * и при нужде, может вам его показать, 
 * также продавец может продать вам товар. 
 * После продажи товар переходит к вам, 
 * и вы можете также посмотреть свои вещи.

Возможные классы – игрок, продавец, товар.

Вы можете сделать так, как вы видите это.
*/
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

        public void Run()
        {
            Seller seller = new Seller("Продавец", 10000);
            Buyer buyer = new Buyer("Покупатель", 100);

            bool isMainLoopActive = true;

            while (isMainLoopActive)
            {
                ShowMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllSellerGoodsCommand:
                        seller.ShowAllItems();
                        break;

                    case BuyItemCommand:
                        MakeDeal(buyer, seller);
                        break;

                    case ShowBuyerInventoryCommand:
                        buyer.ShowAllItems();
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
                        buyer.BuyAllFavouritesFrom(seller);
                        break;

                    case ResetFavouritesCommand:
                        buyer.ResetFavourites();
                        break;

                    case RenewAllSellerGoodsCommand:
                        seller.RenewGoods();
                        break;

                    case ExitCommand:
                        isMainLoopActive = !TryUserWantExit();
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
            seller.ShowAllItems();
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
            seller.ShowAllItems();

            Console.WriteLine($"Выберите что добавить в избранное.");
            Console.WriteLine("Введите индекс товара:");
            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out itemIndex))
            {
                buyer.AddToFavourite(seller.GetName(itemIndex));
            }
            else
            {
                Console.WriteLine($"Не могу распознать цифровой ввод.");
            }
        }

        private void ShowMainMenu()
        {
            string showAllSellerGoods = "Показать все товары продовца.";
            string buyItem = "Купить товар.";
            string showBuyerInventory = "Показать инвентарь покупателя.";
            string returnItemToSeller = "Вернуть товар продавцу.";
            string showAllFavourite = "Показать избранное.";
            string addToFovourite = "Добавить товар в желаемые покупки.";
            string buyAllFavourites = "Купить все товары из списка покупок.";
            string resetFavourites = "Сбросить список избранного.";
            string renewAllSellerGoods = "Обновить товар у продавца.";
            string exitMenuText = "Выход.";

            Console.Clear();
            Console.WriteLine($"{ShowAllSellerGoodsCommand}. {showAllSellerGoods}");
            Console.WriteLine($"{BuyItemCommand}. {buyItem}");
            Console.WriteLine($"{ShowBuyerInventoryCommand}. {showBuyerInventory}");
            Console.WriteLine($"{ReturnItemToSellerCommand}. {returnItemToSeller}");
            Console.WriteLine($"{ShowAllFavouriteCommand}. {showAllFavourite}");
            Console.WriteLine($"{AddToFovouriteCommand}. {addToFovourite}");
            Console.WriteLine($"{BuyAllFavouritesCommand}. {buyAllFavourites}");
            Console.WriteLine($"{ResetFavouritesCommand}. {resetFavourites}");
            Console.WriteLine($"{RenewAllSellerGoodsCommand}. {renewAllSellerGoods}");
            Console.WriteLine($"{ExitCommand}. {exitMenuText}");
            Console.WriteLine();
        }

        private bool TryUserWantExit()
        {
            string userInput;
            Console.Write("Вы хотите выйти? (n - нет, другой - да):");
            userInput = Console.ReadLine();

            if (userInput == "n")
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
        public Seller(string name, int money) : base(name, money)
        {
            base._sellingCoefficient = 1f;

            RenewGoods();
        }

        public bool TrySellProductByName(Trader buyer, string productName)
        {
            int itemIndex = FindIndexByName(productName);

            if (itemIndex >= 0)
            {
                this.Sell(buyer, itemIndex);
                return true;
            }

            return false;
        }

        public void RenewGoods()
        {
            base._items = new List<Item>()
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

        private int FindIndexByName(string name)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name == name)
                    return i;
            }

            return -1;
        }
    }

    class Buyer : Trader
    {
        private List<string> _favourites = new List<string>();

        public Buyer(string name, int money) : base(name, money)
        {
            base._sellingCoefficient = .5f;
        }

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
                Console.WriteLine($"Избранные уже содержат товар {itemName}.");
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

        public void BuyAllFavouritesFrom(Seller seller)
        {
            foreach (string productName in _favourites)
                seller.TrySellProductByName(this, productName);

            ResetFavourites();
        }
    }

    abstract class Trader
    {
        protected List<Item> _items = new List<Item>();

        protected float _sellingCoefficient = 1f;

        public Trader(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; private set; }

        public float Money { get; private set; }

        public void Sell(Trader buyer, int sellingItemIndex)
        {
            if (sellingItemIndex < 0 || sellingItemIndex >= _items.Count)
            {
                Console.WriteLine($"Указанный индекс {sellingItemIndex}" +
                    $" не попадает в границы массива.");
                return;
            }

            Item sellingItem = this._items[sellingItemIndex];
            float sellingPrice = sellingItem.Price * this._sellingCoefficient;

            Console.WriteLine($"Продается {sellingItem.Name} за {sellingPrice} денег.");

            if (buyer.Money >= sellingPrice)
            {
                buyer.TakeMoney(sellingPrice);
                buyer.PutInInventory(sellingItem);
                this._items.Remove(sellingItem);
                this.GiveMoney(sellingPrice);
            }
            else
            {
                Console.WriteLine($"У покупателя не достаточно денег. " +
                    $"Товар стоит {sellingItem.Price} а в наличие только {buyer.Money}"); ;
            }
        }

        protected void PutInInventory(Item item)
        {
            this._items.Add(item);
        }

        protected void TakeMoney(float value)
        {
            Money -= value;
        }

        protected void GiveMoney(float money)
        {
            Money += money;
        }

        public string GetName(int index)
        {
            if (index < 0 || index >= _items.Count)
            {
                Console.WriteLine($"Указанный индекс {index}" +
                    $" не попадает в границы массива.");
                return "";
            }

            return _items[index].Name;
        }

        public void ShowAllItems()
        {
            Console.WriteLine($"Инвентарь \"\"{Name}  Счет: {Money} денег.");

            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"[{i}] {_items[i].Name} цена: {_items[i].Price.ToString("C", new CultureInfo("ru-RU"))}");
            }

            Console.WriteLine();
        }
    }
}
