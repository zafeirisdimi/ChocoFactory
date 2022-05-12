﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Shop
    {
        //properties
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Employee> Employees { get; set; }
        public Dictionary<string, int> DailyProductsSold { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteSchocolate" , 0},
            {"BlackSchocolate" , 0},
            {"PlainMilkSchocolate" , 0},
            {"AlmondMilkSchocolate" , 0},
            {"HazelnutMilkSchocolate" , 0}
        };

        public double DailyEarnings { get; set; }



        //methods
        public void SellProduct(string productName)
        {
            Product productToSell = Products.Find(x => x.Description == productName);
            DailyEarnings += productToSell.Price;
            Products.Remove(productToSell);
            DailyProductsSold[productName]++;
           
        }

        public void EndDay()
        {
            DailyReport();
            SendDailyEarnings();
            DailyEarnings = 0;
            foreach (var productType in DailyProductsSold)
            {
                productType.Value = 0;
            }
            if (IsProductQuantityLow())
            {
                RefillProducts();
            }

        }

        private void DailyReport()
        {
            Console.WriteLine($"ChocoFactory made {DailyEarnings}$ today.");
            Console.WriteLine("Products Sold:");
            foreach (var productType in DailyProductsSold)
            {
                Console.WriteLine($"\t{productType.Key}:{productType.Value}");
            }
        }


        private void SendDailyEarnings()
        {
            company.Money += DailyEarnings;
        }


       
        private void IsProductQuantityLow()//
        {
            if (products.Count <= 62)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        private void RefillProducts()
        {
            do
            {
                Product newProduct = ReceiveProduct();
                products.Add(newProduct);
            } while (products.Count < 250);
        }

        private Product ReceiveProduct()//
        {
            return Factory.Warehouse.SendProduct();
        }
    }
}
