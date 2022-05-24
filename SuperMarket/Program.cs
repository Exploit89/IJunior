using System;
using System.Collections.Generic;

namespace SuperMarket
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
        private List<Customer> _customers;
        private List<Product> _products;
        private int _money;
        private Random _random = new Random();

        public Shop()
        {
            _customers = new List<Customer>();
            _products = new List<Product>();
            int minPrice = 50;
            int maxPrice = 500;

            foreach (ProductName product in Enum.GetValues(typeof(ProductName)))
            {
                int price = _random.Next(minPrice, maxPrice);
                _products.Add(new Product(product, price));
            }
        }

        public void Open()
        {
            bool isOpen = true;
            int minCustomerNumber = 1;
            int maxCustomerNumber = 10;
            Console.WriteLine("Введите число покупателей: ");
            string userInput = Console.ReadLine();

            while (isOpen)
            {
                int customerCount = 0;
                if (int.TryParse(userInput, out int number) && number >= minCustomerNumber && number <= maxCustomerNumber)
                {
                    for (int i = 0; i < number; i++)
                    {
                        _customers.Add(new Customer());
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректное число покупателей от 1 до 10.");
                }

                foreach (var customer in _customers)
                {
                    customerCount++;
                    Serve(customer);
                }

                if (customerCount == _customers.Count)
                {
                    Console.WriteLine($"Обслужено покупателей {customerCount}. Доход составил {_money}\n");
                    isOpen = false;
                }
            }
        }

        private void Serve(Customer customer)
        {
            bool isInsufficient = true;

            while (isInsufficient)
            {
                customer.ShowProducts();
                int sum = 0;

                foreach (var CartProduct in customer.GetProducts())
                {
                    foreach (var product in _products)
                    {
                        if (product.Name == CartProduct.Name)
                            sum += product.Price;
                    }
                }

                if (customer.IsEnough(sum))
                {
                    customer.Pay(sum);
                    _money += sum;
                    isInsufficient = false;
                }
                else
                {
                    customer.ReturnProduct();
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    class Customer
    {
        private Wallet _wallet;
        private Cart _cart;
        private int _maxProductsQuantity;

        public Customer()
        {
            _maxProductsQuantity = 5;
            _wallet = new Wallet();
            _cart = new Cart(_maxProductsQuantity);
        }

        public bool IsEnough(int money)
        {
            return _wallet.IsEnoughMoney(money);
        }

        public void ReturnProduct()
        {
            _cart.ReturnProduct();
        }

        public void Pay(int money)
        {
            _wallet.ReduceMoney(money);
            Console.WriteLine($"Успешно оплачено {money} руб.");
        }

        public List<Product> GetProducts()
        {
            return _cart.GetProducts();
        }

        public void ShowProducts()
        {
            Console.WriteLine("Корзина текущего покупателя:\n");

            foreach (var product in _cart.GetProducts())
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine();
            Console.WriteLine(_wallet.Money);
        }
    }

    class Cart
    {
        private List<Product> _products = new List<Product>();
        private Random _random = new Random();

        public Cart(int maxProductsQuantity)
        {
            bool isTakingProducts = true;

            while (isTakingProducts)
            {
                foreach (ProductName productName in Enum.GetValues(typeof(ProductName)))
                {
                    int allowAddition = 30;
                    int minRandomNumber = 10;
                    int maxRandomNumber = 100;

                    if (_products.Count > maxProductsQuantity)
                        isTakingProducts = false;
                    else if (allowAddition > _random.Next(minRandomNumber, maxRandomNumber))
                        _products.Add(new Product(productName));
                }
            }
        }

        public void ReturnProduct()
        {
            int randomProductIndex = _random.Next(_products.Count);
            Console.WriteLine($"Не хватает денег. Возвращаем товар {_products[randomProductIndex].Name} на полку.");
            _products.RemoveAt(randomProductIndex);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _products;
            return products;
        }
    }

    class Product
    {
        public ProductName Name;
        public int Price { get; private set; }

        public Product(ProductName name, int price = 0)
        {
            Name = name;
            Price = price;
        }
    }

    class Wallet
    {
        public int Money { get; private set; }
        private Random _random = new Random();
        public Wallet()
        {
            int minMoneyValue = 1000;
            int maxMoneyValue = 2000;
            Money = _random.Next(minMoneyValue, maxMoneyValue);
        }

        public void ReduceMoney(int money)
        {
            Money -= money;
        }

        public bool IsEnoughMoney(int money)
        {
            return Money >= money;
        }
    }

    enum ProductName
    {
        Martini,
        Beer,
        Vodka,
        Whiskey,
        Vine,
        Icecream,
        Rum,
        Cookies,
        Elephant,
        Mars,
        Water,
        Potato,
        Pen
    }
}
