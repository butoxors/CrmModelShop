﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();

        Random rnd = new Random();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();

        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSeller(20);
            Generator.GetNewProducts(1000);
            Generator.GetCustomers(100);

            foreach(var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = Generator.GetCustomers(10);
            var carts = new Queue<Cart>();

            foreach(var customer in customers)
            {
                var cart = new Cart(customer);
                foreach(var prod in Generator.GetRandomProducts(10, 30))
                {
                    cart.Add(prod);
                }
                carts.Enqueue(cart);
            }

            while(carts.Count > 0)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)]; // TODO:
                cash.Enqueue(carts.Dequeue());
            }

            while (true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)]; // TODO:
                var money = cash.Dequeue();
            }
        }
    }
}
