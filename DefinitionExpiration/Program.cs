using System;
using System.Collections.Generic;
using System.Linq;

namespace DefinitionExpiration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Open();
        }
    }

    class Shop
    {
        private List<Product> _products;
        private Random _random = new Random();
        private int _currentYear = 2022;

        public Shop()
        {
            int minProductionYear = 2019;
            int maxProductionYear = 2022;
            int minExpirtaionYear = 1;
            int maxExpirtaionYear = 3;
            _products = new List<Product>();
            _products.Add(new Product("Тушенка", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Грибы", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Корнишоны", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Помидоры", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Огурцы", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Перец", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Горох", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Кукуруза", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Шляпаусатая", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Тринитротолуол", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
            _products.Add(new Product("Зубной порошок", _random.Next(minProductionYear, maxProductionYear), _random.Next(minExpirtaionYear, maxExpirtaionYear)));
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine(" \nМеню:" +
                    " \n1. Показать просрочку" +
                    " \n2. Показать все товары" +
                    " \n3. Выход\n");
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.D1:
                        ShowExpiredProducts();
                        break;
                    case ConsoleKey.D2:
                        ShowAllProducts();
                        break;
                    case ConsoleKey.D3:
                        isOpen = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void ShowExpiredProducts()
        {
            Console.Clear();
            Console.WriteLine("Просроченные товары: ");
            var sortedProducts = _products.Where(product => _currentYear - product.ProductionYear > product.ExpirationYear);

            foreach (var product in sortedProducts)
                Console.WriteLine($"{product.Name}. Год изготовления: {product.ProductionYear}. Срок годности: {product.ExpirationYear} год(лет)");
        }

        private void ShowAllProducts()
        {
            Console.Clear();
            Console.WriteLine("Все товары: ");

            foreach (var product in _products)
                Console.WriteLine($"{product.Name}. Год изготовления: {product.ProductionYear}. Срок годности: {product.ExpirationYear}");
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует.");
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ExpirationYear { get; private set; }

        public Product(string name, int productionYear, int expirationYear)
        {
            Name = name;
            ProductionYear = productionYear;
            ExpirationYear = expirationYear;
        }
    }
}
