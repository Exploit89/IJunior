using System;
using System.Collections.Generic;

namespace MyFirstApp
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
            private protected List<Stack> _goods = new List<Stack>();
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
                    Product product = new Product(productName, randomPrice);
                    _goods.Add(new Stack(product, randomQuantity));
                }
            }

            public void GetCash(int cash)
            {
                _cash += cash;
            }

            public Stack GetStack(Goods productName)
            {
                Stack product = null;

                foreach (var stack in _goods)
                {
                    if (stack.GetName() == productName)
                        product = stack;
                }

                return product;
            }

            virtual public void ShowGoods()
            {
                Console.Clear();
                Console.WriteLine("Товары, доступные для покупки: \n");

                foreach (var stack in _goods)
                {
                    Console.WriteLine($"{stack.GetName()} - Цена: {stack.GetProduct().Price} руб. - {stack.Quantity} шт.");
                }

                Console.WriteLine();
            }

            public int GetPrice(Goods productName)
            {
                int productPrice = 0;
                foreach (var stack in _goods)
                {
                    if (productName == stack.GetName())
                        productPrice = stack.GetProduct().Price;
                }
                return productPrice;
            }

            public List<Stack> GetAllStacks()
            {
                List<Stack> products = new List<Stack>();

                foreach (var stack in _goods)
                {
                    products.Add(stack);
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
                    Product product = new Product(productName, shop.GetPrice(productName));
                    _goods.Add(new Stack(product, 0));
                }
            }

            override public void ShowGoods()
            {
                int sum = 0;
                Console.Clear();
                Console.WriteLine("Ваша корзина:\n");

                foreach (var stack in _goods)
                {
                    int sumEach = 0;
                    sumEach = stack.GetProduct().Price * stack.Quantity;
                    sum += stack.GetProduct().Price * stack.Quantity;
                    Console.WriteLine($"{stack.GetProduct().Name} - Цена: {stack.GetProduct().Price} руб. - {stack.Quantity} шт. на сумму {sum} руб.");
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
                    Product product = new Product(productName, shop.GetPrice(productName));
                    _goods.Add(new Stack(product, 0));
                }
            }

            override public void ShowGoods()
            {
                Console.Clear();
                Console.WriteLine("Ваши продукты:\n");

                foreach (var stack in _goods)
                {
                    _cash -= stack.GetProduct().Price * stack.Quantity;
                    Console.WriteLine($"{stack.GetProduct().Name} - {stack.Quantity}");
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

            public Product(Goods name, int price)
            {
                Name = name;
                Price = price;
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
                            BuyProducts(cart, customer, shop);
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
                shop.GetStack(productName).ReduceQuantity(quantity);
                cart.GetStack(productName).IncreaseQuantity(quantity);
                Console.Clear();
            }

            private void ReturnProductQuantity(Goods product, Shop shop, Cart cart)
            {
                Console.Write("Сколько хотите вернуть?\n");
                string userInput = Console.ReadLine();
                int quantity = GetCorrectNumber(userInput, cart, product);
                shop.GetStack(product).IncreaseQuantity(quantity);
                cart.GetStack(product).ReduceQuantity(quantity);
            }

            private int GetCorrectNumber(string numberString, Shop shop, Goods product)
            {
                int quantity = shop.GetStack(product).Quantity;

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
                int quantity = cart.GetStack(product).Quantity;

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

            private void BuyProducts(Cart cart, Customer customer, Shop shop)
            {
                foreach (var stack in customer.GetAllStacks())
                {
                    int sum = stack.GetProduct().Price * stack.Quantity;
                    customer.GetStack(stack.GetName()).IncreaseQuantity(cart.GetStack(stack.GetName()).Quantity);
                    cart.GetStack(stack.GetName()).ReduceQuantity(stack.Quantity);
                    customer.GiveCash(sum);
                    shop.GetCash(sum);
                }

                Console.Clear();
                Console.WriteLine($"Успешно совершена покупка!\n");
            }

            private void ShowDefaultMessage()
            {
                Console.Clear();
                Console.WriteLine("Такой команды не существует.");
            }
        }

        class Stack
        {
            private Product _product;

            public int Quantity { get; private set; }

            public Stack(Product product, int quantity)
            {
                _product = product;
                Quantity = quantity;
            }

            public void IncreaseQuantity(int quantity)
            {
                Quantity += quantity;
            }

            public void ReduceQuantity(int quantity)
            {
                Quantity -= quantity;
            }

            public Goods GetName()
            {
                return _product.Name;
            }

            public Product GetProduct()
            {
                return _product;
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
