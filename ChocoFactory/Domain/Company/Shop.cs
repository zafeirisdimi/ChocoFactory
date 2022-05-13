using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    internal class Shop
    {
        public Company Company { get; set; }
        public Factory Factory { get; set; }
        public double Discount { get; set; } = 0;
        public List<Product> Products { get; set; } = new List<Product>();
        
        public List<Employee> Employees { get; set; }

        public Dictionary<string, int> DailyProductsSold { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteChocolate" , 0},
            {"BlackChocolate" , 0},
            {"PlainMilkChocolate" , 0},
            {"AlmondMilkChocolate" , 0},
            {"HazelnutMilkChocolate" , 0}
        };
        public string Location { get; set; }
        public decimal DailyEarnings { get; set; } = 0;

        // Constructor

        public Shop(Company company)
        {
            Company = company;
        }

        //methods
        public decimal SellProduct(string productName)
        {
            Product productToSell = Products.Find(x => x.Description == productName);
            decimal productPrice = productToSell.Price;
            DailyEarnings += productPrice;
            Products.Remove(productToSell);
            DailyProductsSold[productName]++;

            return productPrice;
        }

        public decimal ServeCustomer(List<string> productsToSell)
        {
            decimal totalCost = 0;
            foreach (string product in productsToSell)
            {
                totalCost += SellProduct(product);
            }

            if (totalCost >= 30 && HasExperimentalProduct())
            {
                Products.Remove(Products.Find(x=>x.Description=="ExperimentalProduct"));
            }
            return totalCost;
        }

        public void DailyActions(DateTime date)
        {
            DailyReport();
            SendDailyEarnings();
            DailyEarnings = 0;
            foreach (var productType in DailyProductsSold.Keys.ToList<string>())
            {
                DailyProductsSold[productType] = 0;

                //productType.Value = 0;
            }
            RemoveExpiredProducts(date);

            if (IsProductQuantityLow())
            {
                RefillProducts();
            }

        }

        private void DailyReport()
        {

            Console.WriteLine($"Our shop at {Location} made {DailyEarnings} Euro today.");
            Console.WriteLine("Products Sold:");
            foreach (var productType in DailyProductsSold)
            {
                Console.WriteLine($"\t{productType.Key}:{productType.Value}");
            }
        }


        private void SendDailyEarnings()
        {
            Company.Revenue += DailyEarnings;
        }

        private bool IsProductQuantityLow()
        {
            return Products.Count <= Company.CompanyPolicy.ShopRestockThreshold;
        }


        private void RefillProducts()
        {
            foreach (string productName in DailyProductsSold.Keys.ToList<string>())
            {
                while (Products.Count < Company.CompanyPolicy.ShopStockSize)
                {
                    ReceiveProduct(productName);
                    
                }
            }
        }

        public void ReceiveProduct(string productName)//
        {
            Product newProduct = Factory.Warehouse.SendProduct(productName);
            Products.Add(newProduct);
            
        }
        private void RemoveExpiredProducts(DateTime currentDate)
        {
            foreach (Product product in Products)
            {
                if (product.ExpirationDate > currentDate)
                {
                    Products.Remove(product);
                }
            }
        }

        private bool HasExperimentalProduct()
        {
            return Products.Any(x => x.Description == "ExperimentalProduct");
        }
    }
}
