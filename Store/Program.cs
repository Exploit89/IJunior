using System;
using System.Collections.Generic;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Cart cart = new Cart();
        }

        class Shop
        {
            private List<Goods> _goodsNames = new List<Goods>();
            private List<Product> _goods = new List<Product>();
            private float _cash;
            private int _minPrice = 10;
            private int _maxPrice = 100;
            private int _minQuantity = 5;
            private int _maxQuantity = 20;


            public Shop()
            {
                Random random = new Random();

                _goodsNames.Add(Goods.Water);
                _goodsNames.Add(Goods.Apple);
                _goodsNames.Add(Goods.Cheese);
                _goodsNames.Add(Goods.Meat);
                _goodsNames.Add(Goods.Bread);

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

            public void GiveProduct(Goods productName, int quantity)
            {
                Product product = GetProduct(productName);
                product.ReduceQuantity(quantity);
            }

            public void TakeProduct(Goods productName, int quantity)
            {
                Product product = GetProduct(productName);
                product.IncreaseQuantity(quantity);
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

            public void ShowGoods()
            {
                foreach (var item in _goods)
                {
                    Console.WriteLine($"{item.Name} - {item.Price} - {item.Quantity}");
                }
            }
        }

        class Cart : Shop
        {
            private List<Product> _goods = new List<Product>();

            public Cart()
            {
                Random random = new Random();

                _goodsNames.Add(Goods.Water);
                _goodsNames.Add(Goods.Apple);
                _goodsNames.Add(Goods.Cheese);
                _goodsNames.Add(Goods.Meat);
                _goodsNames.Add(Goods.Bread);

                foreach (var productName in _goodsNames)
                {
                    _goods.Add(new Product(productName, randomPrice, randomQuantity));
                }
            }

            new public void ShowGoods()
            {
                int sum = 0;

                foreach (var item in _goods)
                {
                    sum += item.Price * item.Quantity;
                    Console.WriteLine($"{item.Name} - {item.Price} - {item.Quantity}");
                }

                Console.WriteLine($"Сумма покупок: {sum}");
            }
        }

        class Customer
        {

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
