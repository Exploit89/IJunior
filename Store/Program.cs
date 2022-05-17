using System;
using System.Collections.Generic;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Seller seller = new Seller();
            Customer customer = new Customer();
            Cart cart = new Cart();
            seller.OpenShop(shop, customer, cart);
        }
    }

    class Seller
    {
        public void OpenShop(Shop shop, Customer customer, Cart cart)
        {
            bool isOpen = true;
            string userInput;

            while (isOpen)
            {
                shop.ShowGoods();
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        TakeProductTo(cart);
                        break;
                    default:
                        break;
                }
            }
        }
        //TODO как-то получить товары магазина и перебрать
        private void TakeProductTo(Cart cart)
        {
            Console.WriteLine("Какой товар вы хотите взять?\n");
            string userInputProduct = Console.ReadLine();

            foreach(var item in )

            cart.AddProduct(shop, product, quantity);
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

    class Customer
    {
        private Dictionary<Product, int> _goods = new Dictionary<Product, int>();
        private float _cash = 2000;

        public Customer()
        {
            Cart cart = new Cart();
        }

        public void TakeGoods(Product product, int quantity)
        {
            _goods.Add(product, quantity);
        }

        public void GiveCashTo(Shop shop, Cart cart)
        {
            shop.TakeSumFrom(cart);
            if(isEnoughCash(cart))
                _cash -= cart.CashSum;
            else
                Console.WriteLine("Недостаточно денег.");
        }

        private bool isEnoughCash(Cart cart)
        {
            return (_cash -= cart.CashSum) >= 0;
        }
    }

    class Shop
    {
        private Dictionary<Product, int> _goods;
        private float _cash;

        public Shop()
        {
            _goods = new Dictionary<Product, int>();
            _goods.Add(new Product(Goods.Apple, 57), 10);
            _goods.Add(new Product(Goods.Water, 28), 10);
            _goods.Add(new Product(Goods.Bread, 43), 10);
            _goods.Add(new Product(Goods.Meat, 134), 5);
            _goods.Add(new Product(Goods.Cheese, 125), 5);
            Customer customer = new Customer();
        }

        public void Sell(Cart cart)
        {
            TakeSumFrom(cart);
            cart.ClearCart();
            Console.WriteLine($"Совершена покупка на сумму {cart.CashSum} руб.");
        }

        public void TakeSumFrom(Cart cart)
        {
            _cash += cart.CashSum;
        }

        public void RemoveProduct(Product product, int quantity)
        {
            int goodsQuantity = 0;

            foreach (var item in _goods)
            {
                if(item.Key == product)
                {
                    goodsQuantity = item.Value - quantity;
                }
            }

            if (goodsQuantity == 0 && EnoughGoods(product, quantity))
            {
                _goods.Remove(product);
            }
            else if (goodsQuantity < 0)
            {
                goodsQuantity += quantity;
            }
            else
            {
                _goods.Remove(product);
                _goods.Add(product, goodsQuantity);
            }
        }

        public bool EnoughGoods(Product product, int quantity)
        {
            bool enough = false;

            foreach (var item in _goods)
            {
                if (item.Key == product && item.Value - quantity > 0)
                    enough = true;
                else
                    enough = false;
            }

            return enough;
        }

        public void ReturnGoods(Cart cart)
        {
            foreach(var item in cart.GetCartContains())
            {
                _goods.Add(item.Key, item.Value);
            }

            cart.ClearCart();
        }

        public void ShowGoods()
        {
            Console.WriteLine("Магазин:");

            foreach (var product in _goods)
            {
                Console.WriteLine($"{product.Key.Name} - {product.Value} шт. Цена - {product.Key.Price} руб. за 1 шт.");
            }
        }
    }

    class Cart
    {
        private Dictionary<Product, int> _goods;

        public float CashSum { get; private set; }

        public Cart()
        {
            _goods = new Dictionary<Product, int>();
        }

        public void AddProduct(Shop shop, Product product, int quantity)
        {
            if (shop.EnoughGoods(product, quantity))
            {
                shop.RemoveProduct(product, quantity);
                _goods.Add(product, quantity);
            }
            else
            {
                Console.WriteLine("Вы положили в корзину все товары этого вида.");
            }
        }

        public void RemoveProduct(Product product, int quantity)
        {
            int goodsQuantity = 0;

            foreach (var item in _goods)
            {
                if (item.Key == product)
                {
                    goodsQuantity = item.Value - quantity;
                }
            }

            if (goodsQuantity == 0)
            {
                _goods.Remove(product);
            }
            else if (goodsQuantity < 0)
            {
                goodsQuantity += quantity;
                Console.WriteLine("В корзине недостаточно этого товара.");
            }
            else
            {
                _goods.Remove(product);
                _goods.Add(product, goodsQuantity);
            }
        }

        public void GiveGoodsTo(Customer customer, Product product, int quantity)
        {
            customer.TakeGoods(product, quantity);
            RemoveProduct(product, quantity);
        }

        public void ClearCart()
        {
            _goods.Clear();
        }

        public void ShowCart()
        {
            float sum = 0;
            foreach(var product in _goods)
            {
                sum += product.Value * product.Key.Price;
                Console.WriteLine($"Ваша корзина:\n" +
                    $"{product.Key} - {product.Value} шт. по цене {product.Key.Price} руб. на сумму {sum}\n");
            }

            CashSum = sum;
            Console.WriteLine($"Стоимость товаров в вашей корзине: {sum} руб.");
        }

        public Dictionary<Product, int> GetCartContains()
        {
            Dictionary<Product, int> cartDictionary = new Dictionary<Product, int>();

            foreach (var product in _goods)
            {
                cartDictionary.Add(product.Key, product.Value);
            }

            return cartDictionary;
        }
    }

    enum Goods
    {
        Apple,
        Water,
        Bread,
        Meat,
        Cheese
    }
}
