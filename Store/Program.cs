using System;
using System.Collections.Generic;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Cart cart = new Cart(shop);
            Customer customer = new Customer(shop);
            Seller seller = new Seller();
            seller.OpenShop(shop, cart, customer);
        }

        class Shop
        {
            private protected List<Goods> _goodsNames = new List<Goods>();
            private protected List<Product> _goods = new List<Product>();
            private protected float _cash;
            private int _minPrice = 10;
            private int _maxPrice = 100;
            private int _minQuantity = 5;
            private int _maxQuantity = 20;

            public Shop()
            {
                Random random = new Random();

                _goodsNames.Add(Goods.Вода);
                _goodsNames.Add(Goods.Яблоко);
                _goodsNames.Add(Goods.Сыр);
                _goodsNames.Add(Goods.Мясо);
                _goodsNames.Add(Goods.Хлеб);

                foreach (var productName in _goodsNames)
                {
                    int randomPrice = random.Next(_minPrice, _maxPrice);
                    int randomQuantity = random.Next(_minQuantity, _maxQuantity);
                    _goods.Add(new Product(productName, randomPrice, randomQuantity));
                }
            }

            public void GetCash(int cash)
            {
                _cash += cash;
            }

            public Product GetProduct(Goods productName)
            {
                Product product = null;

                foreach (var item in _goods)
                {
                    if (item.Name == productName)
                        product = item;
                }

                return product;
            }

            virtual public void ShowGoods()
            {
                Console.Clear();
                Console.WriteLine("Товары, доступные для покупки: \n");

                foreach (var product in _goods)
                {
                    Console.WriteLine($"{product.Name} - Цена: {product.Price} руб. - {product.Quantity} шт.");
                }

                Console.WriteLine();
            }

            public int GetPrice(Goods productName)
            {
                int productPrice = 0;
                foreach (var product in _goods)
                {
                    if (productName == product.Name)
                        productPrice = product.Price;
                }
                return productPrice;
            }

            public List<Product> GetAllProducts()
            {
                List<Product> products = new List<Product>();

                foreach (var product in _goods)
                {
                    products.Add(product);
                }

                return products;
            }
        }

        class Cart : Shop
        {
            public Cart(Shop shop)
            {
                _goods.Clear();

                foreach (var productName in _goodsNames)
                {
                    _goods.Add(new Product(productName, shop.GetPrice(productName), 0));
                }
            }

            override public void ShowGoods()
            {
                int sum = 0;
                Console.Clear();
                Console.WriteLine("Ваша корзина:\n");

                foreach (var product in _goods)
                {
                    sum += product.Price * product.Quantity;
                    Console.WriteLine($"{product.Name} - Цена: {product.Price} руб. - {product.Quantity} шт. на сумму {sum} руб.");
                }

                Console.WriteLine($"Итого сумма покупок: {sum}\n");
            }
        }

        class Customer : Shop
        {
            private int _minCash = 1000;
            private int _maxCash = 3000;

            public Customer(Shop shop)
            {
                Random randomCash = new Random();
                _goods.Clear();
                _cash = randomCash.Next(_minCash, _maxCash);

                foreach (var productName in _goodsNames)
                {
                    _goods.Add(new Product(productName, shop.GetPrice(productName), 0));
                }
            }

            override public void ShowGoods()
            {
                Console.Clear();
                Console.WriteLine("Ваши продукты:\n");

                foreach (var product in _goods)
                {
                    _cash -= product.Price * product.Quantity;
                    Console.WriteLine($"{product.Name} - {product.Quantity}");
                }

                Console.WriteLine($"Осталось денег: {_cash}\n");
            }

            public void GiveCash(int cash)
            {
                _cash -= cash;
            }
        }

        class Product
        {
            public Goods Name { get; private set; }
            public int Price { get; private set; }
            public int Quantity { get; private set; }

            public Product(Goods name, int price, int quantity = 0)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public void ReduceQuantity(int quantity)
            {
                Quantity -= quantity;
            }

            public void IncreaseQuantity(int quantity)
            {
                Quantity += quantity;
            }
        }

        class Seller
        {
            public void OpenShop(Shop shop, Cart cart, Customer customer)
            {
                bool isOpen = true;

                while (isOpen)
                {
                    string userInput;
                    Console.WriteLine("Меню:" +
                        "\n1. Каталог товаров." +
                        "\n2. Состав корзины." +
                        "\n3. Ваши приобретенные товары." +
                        "\n4. Взять товар с полки." +
                        "\n5. Вернуть товар на полку." +
                        "\n6. Завершить покупку." +
                        "\n7. Выход");

                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            shop.ShowGoods();
                            break;
                        case "2":
                            cart.ShowGoods();
                            break;
                        case "3":
                            customer.ShowGoods();
                            break;
                        case "4":
                            TakeProductToCart(shop, cart);
                            break;
                        case "5":
                            ReturnProductToShop(shop, cart);
                            break;
                        case "6":
                            BuyProducts(cart, customer);
                            break;
                        case "7":
                            isOpen = false;
                            break;
                        default:
                            ShowDefaultMessage();
                            break;
                    }
                }
            }

            private void TakeProductToCart(Shop shop, Cart cart)
            {
                bool isChoosing = true;

                while (isChoosing)
                {
                    string userInput;
                    Console.WriteLine("Выберите товар:" +
                        "\n1. Яблоко." +
                        "\n2. Вода." +
                        "\n3. Мясо." +
                        "\n4. Сыр." +
                        "\n5. Хлеб." +
                        "\n6. Вернуться в меню.");

                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            TakeProductQuantity(Goods.Яблоко, shop, cart);
                            break;
                        case "2":
                            TakeProductQuantity(Goods.Вода, shop, cart);
                            break;
                        case "3":
                            TakeProductQuantity(Goods.Мясо, shop, cart);
                            break;
                        case "4":
                            TakeProductQuantity(Goods.Сыр, shop, cart);
                            break;
                        case "5":
                            TakeProductQuantity(Goods.Хлеб, shop, cart);
                            break;
                        case "6":
                            isChoosing = false;
                            break;
                        default:
                            ShowDefaultMessage();
                            break;
                    }
                }
            }

            private void ReturnProductToShop(Shop shop, Cart cart)
            {
                bool isChoosing = true;

                while (isChoosing)
                {
                    string userInput;
                    Console.WriteLine("Выберите товар:" +
                        "\n1. Яблоко." +
                        "\n2. Вода." +
                        "\n3. Мясо." +
                        "\n4. Сыр." +
                        "\n5. Хлеб." +
                        "\n6. Вернуться в меню.");

                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            ReturnProductQuantity(Goods.Яблоко, shop, cart);
                            break;
                        case "2":
                            ReturnProductQuantity(Goods.Вода, shop, cart);
                            break;
                        case "3":
                            ReturnProductQuantity(Goods.Мясо, shop, cart);
                            break;
                        case "4":
                            ReturnProductQuantity(Goods.Сыр, shop, cart);
                            break;
                        case "5":
                            ReturnProductQuantity(Goods.Хлеб, shop, cart);
                            break;
                        case "6":
                            isChoosing = false;
                            break;
                        default:
                            ShowDefaultMessage();
                            break;
                    }
                }
            }

            private void TakeProductQuantity(Goods productName, Shop shop, Cart cart)
            {
                Console.Write("Сколько хотите взять?\n");
                string userInput = Console.ReadLine();
                int quantity = GetCorrectNumber(userInput, shop, productName);
                shop.GetProduct(productName).ReduceQuantity(quantity);
                cart.GetProduct(productName).IncreaseQuantity(quantity);
            }

            private void ReturnProductQuantity(Goods product, Shop shop, Cart cart)
            {
                Console.Write("Сколько хотите вернуть?\n");
                string userInput = Console.ReadLine();
                int quantity = GetCorrectNumber(userInput, cart, product);
                shop.GetProduct(product).IncreaseQuantity(quantity);
                cart.GetProduct(product).ReduceQuantity(quantity);
            }

            private int GetCorrectNumber(string numberString, Shop shop, Goods product)
            {
                int quantity = shop.GetProduct(product).Quantity;

                if (int.TryParse(numberString, out int number))
                {
                    if (number > 0 && number <= quantity)
                    {
                        return number;
                    }
                }

                Console.WriteLine("Ошибка! Введите корректное число.");
                return 0;
            }

            private int GetCorrectNumber(string numberString, Cart cart, Goods product)
            {
                int quantity = cart.GetProduct(product).Quantity;

                if (int.TryParse(numberString, out int number))
                {
                    if (number > 0 && number <= quantity)
                    {
                        return number;
                    }
                }

                Console.WriteLine("Ошибка! Введите число больше нуля.");
                return 0;
            }

            private void BuyProducts(Cart cart, Customer customer)
            {
                foreach (var product in customer.GetAllProducts())
                {
                    int sum = product.Price * product.Quantity;
                    customer.GetProduct(product.Name).IncreaseQuantity(cart.GetProduct(product.Name).Quantity);
                    cart.GetProduct(product.Name).ReduceQuantity(cart.GetProduct(product.Name).Quantity);
                    customer.GiveCash(sum);
                }
            }

            private void ShowDefaultMessage()
            {
                Console.Clear();
                Console.WriteLine("Такой команды не существует.");
            }
        }
    }

    enum Goods
    {
        Яблоко,
        Вода,
        Хлеб,
        Мясо,
        Сыр
    }
}
