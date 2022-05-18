using System;
using System.Collections.Generic;

namespace MyFirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Cart cart = new Cart();
            shop.ShowGoods();
            Console.WriteLine();
            shop.GiveProduct("apple", 3);
            shop.ShowGoods();
        }

        class Product
        {
            public string Name { get; private set; }
            public int Price { get; private set; }
            public int Quantity { get; private set; }

            public Product(string name, int price, int quantity = 1)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public void ReduceQuantity(int quantity)
            {
                Quantity -= quantity;
            }
        }

        class Cart
        {
            private List<Product> _goods = new List<Product>();
        }

        class Shop
        {
            private List<Product> _goods = new List<Product>();
            private float _cash;

            public Shop()
            {
                _goods.Add(new Product("apple", 100, 25));
                _goods.Add(new Product("bread", 50, 5));
            }

            public void GetCash(int cash)
            {
                _cash += cash;
            }

            public void GiveProduct(string productName, int quantity)
            {
                Product product = GetProduct(productName);
                product.ReduceQuantity(quantity);
            }

            private Product GetProduct(string productName)
            {
                Product product = null;

                foreach(var item in _goods)
                {
                    if (item.Name == productName)
                        product = item;
                }

                return product;
            }

            public void ShowGoods()
            {
                foreach(var item in _goods)
                {
                    Console.WriteLine($"{item.Name} - {item.Price} - {item.Quantity}");
                }
            }
        }

        class Seller
        {

        }
    }
}
