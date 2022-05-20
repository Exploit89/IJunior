using System;
using System.Collections.Generic;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Player player = new Player();
            seller.OpenShop(player);
        }
    }

    class Seller
    {
        private List<Stack> _products = new List<Stack>();

        public Seller()
        {
            Random random = new Random();
            int minPrice = 10;
            int maxPrice = 100;
            int minQuantity = 1;
            int maxQuantity = 10;

            foreach (Products productName in Enum.GetValues(typeof(Products)))
            {
                int newPrice = random.Next(minPrice, maxPrice);
                int newQuantity = random.Next(minQuantity, maxQuantity);
                _products.Add(new Stack(new Product(productName, newPrice), newQuantity));
            }
        }

        public void OpenShop(Player player)
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Меню:" +
                    "\n1. - Посмотреть товар." +
                    "\n2. - Купить товар." +
                    "\n3. - Показать купленные товары." +
                    "\n4. - Выход.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        BuyProduct(player);
                        break;
                    case "3":
                        player.ShowProducts();
                        break;
                    case "4":
                        isOpen = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void ShowProducts()
        {
            Console.Clear();

            foreach (Stack stack in _products)
            {
                Console.WriteLine($"{stack.Product.Name} - {stack.Product.Price} руб. - {stack.Quantity} шт.");
            }

            Console.WriteLine();
        }

        private void BuyProduct(Player player)
        {
            Products userChosenName = ChooseProduct();
            if (userChosenName == 0)
            {
                Console.WriteLine("Такого товара нет.");
            }
            else
            {
                int userQuantity = ChooseQuantity(userChosenName);

                if (userQuantity == 0)
                {
                    Console.WriteLine("Попробуйте снова.\n");
                }
                else
                {
                    foreach (Stack stack in _products)
                    {
                        if (userChosenName == stack.Product.Name)
                        {
                            int sum = stack.Product.Price * userQuantity;
                            player.TakeProduct(stack, userQuantity);
                            player.Wallet.DecreaseCash(sum);
                            GiveProduct(stack, userQuantity);
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Товар успешно куплен.\n");
                }
            }
        }

        private Products ChooseProduct()
        {
            Products[] productNames = (Products[])Enum.GetValues(typeof(Products));
            Console.WriteLine("Выберите товар:\n");

            for (int i = 0; i < productNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {productNames[i]}");
            }

            Console.WriteLine();
            string userInput = Console.ReadLine();
            int userNumber = GetCorrectNumber(userInput);


            Products userChosenName = 0;

            for (int i = 0; i < productNames.Length; i++)
            {
                if (i + 1 == userNumber && userNumber <= productNames.Length)
                    userChosenName = productNames[i];
            }
            return userChosenName;
        }

        private int ChooseQuantity(Products product)
        {
            Console.WriteLine("Сколько вы хотите приобрести?\n");
            string userInput = Console.ReadLine();
            int userQuantity = GetCorrectNumber(userInput);

            foreach (var stack in _products)
            {
                if (product == stack.Product.Name && stack.Quantity >= userQuantity)
                    return userQuantity;
            }

            Console.WriteLine("Такого количества товара нет у продавца.");
            return 0;
        }

        private void GiveProduct(Stack stack, int quantity)
        {
            foreach (Stack product in _products)
            {
                if (stack == product)
                    product.DecreaseQuantity(quantity);
            }
        }

        private int GetCorrectNumber(string userInput)
        {
            if (isNumber(userInput))
            {
                return Convert.ToInt32(userInput);
            }

            Console.WriteLine("Введено некорректное число.");
            return 0;
        }

        private bool isNumber(string userInput)
        {
            return int.TryParse(userInput, out var number);
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует.");
        }
    }

    class Player
    {
        private List<Stack> _products = new List<Stack>();
        private Random _randomCash = new Random();
        private int _minCash = 1000;
        private int _maxCash = 3000;

        public Wallet Wallet { get; private set; }

        public Player()
        {
            int newCash = _randomCash.Next(_minCash, _maxCash);
            Wallet = new Wallet(newCash);

            foreach (Products productName in Enum.GetValues(typeof(Products)))
            {
                _products.Add(new Stack(new Product(productName, 0), 0));
            }
        }

        public void ShowProducts()
        {
            Console.Clear();

            foreach (var stack in _products)
            {
                Console.WriteLine($"{stack.Product.Name} - {stack.Quantity} шт.");
            }

            Console.WriteLine($"Осталось денег: {Wallet.Cash} руб.");
            Console.WriteLine();
        }

        public void TakeProduct(Stack stack, int quantity)
        {
            foreach (Stack product in _products)
            {
                if (product.Product.Name == stack.Product.Name)
                    product.IncreaseQuantity(quantity);
            }
        }
    }

    class Stack
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public Stack(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            Quantity -= quantity;
        }
    }

    class Product
    {
        public Products Name { get; private set; }
        public int Price { get; private set; }

        public Product(Products productName, int price)
        {
            Name = productName;
            Price = price;
        }
    }

    class Wallet
    {
        public int Cash { get; private set; }

        public Wallet(int cash)
        {
            Cash = cash;
        }

        public void DecreaseCash(int value)
        {
            Cash -= value;
        }
    }

    enum Products
    {
        Meat = 1,
        Cheese,
        Water,
        Apple,
        Bread
    }
}
