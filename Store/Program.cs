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
            shop.ShowGoods();
            Console.WriteLine();
            shop.GiveProduct(Goods.Apple, 3);
            shop.ShowGoods();
        }

        class Product
        {
            public Goods Name { get; private set; }
            public int Price { get; private set; }
            public int Quantity { get; private set; }

            public Product(Goods name, int price, int quantity = 1)
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
            private List<Goods> _goodsNames = new List<Goods>();
            private List<Product> _goods = new List<Product>();
            private float _cash;

            public Shop()
            {
                _goodsNames.Add(Goods.Water);
                _goodsNames.Add(Goods.Apple);
                _goodsNames.Add(Goods.Cheese);
                _goodsNames.Add(Goods.Meat);
                _goodsNames.Add(Goods.Bread);

                foreach (var productName in _goodsNames)
                {
                    _goods.Add(new Product(productName, 100, 25));
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

            private Product GetProduct(Goods productName)
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
