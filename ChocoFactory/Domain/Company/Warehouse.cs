using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    class Warehouse : Department
    {
        public Factory Factory { get; set; }

        //properties
        public List<Product> Products { get; set; } = new List<Product>();
        public Dictionary<string, int> ProductQuantity { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteChocolate" , 0},
            {"BlackChocolate" , 0},
            {"PlainMilkChocolate" , 0},
            {"AlmondMilkChocolate" , 0},
            {"HazelnutMilkChocolate" , 0}
        };
        public int SuppliesInKilo { get; set; }
        public int ExperimentalSupplies { get; set; }
        public bool AreSuppliesLow
        {
            get
            {
                return SuppliesInKilo <= Factory.Accounting.LastOrder.Quantity * Factory.Company.CompanyPolicy.LowSuppliesThresholdPercent;
            }
        }

        public Warehouse(Factory factory)
        {
            Factory = factory;
        }


        //methods

        public void DailyActions(DateTime currentDate)
        {
            RemoveExpiredProducts(currentDate);
            GetDailyProducts();

            if (AreSuppliesLow)
            {
                Factory.Accounting.SendOrder(Factory.Accounting.LastOrder);
            }
        }

        public void GetSupplies(int supplies)
        {
            SuppliesInKilo += supplies;
        }

        public void SendSupplies(int kilos)//called from Production
        {
            SuppliesInKilo -= kilos;          
        }

        public void GetProduct(string productName)
        {
            Product newProduct = Factory.Production.CreateProduct(productName);
            Products.Add(newProduct);
            ProductQuantity[productName]++;
        }

        public Product SendProduct(string productName)
        {
            Product productToSend = Products.Find(x => x.Description == productName);
            Products.Remove(productToSend);
            ProductQuantity[productName]--;
            return productToSend;
        }

        private void RemoveExpiredProducts(DateTime currentDate)
        {
            Product product;

            for (int i = 0; i < Products.Count; i++)
            {
                product = Products[i];
                if (product.ExpirationDate > currentDate)
                {
                    ProductQuantity[product.Description]--;
                    Products.Remove(product);
                }
            }
        }

        public void RefillProduct(string productName, double policyPercentage)
        {
            for (int i = 1; i <= policyPercentage * Factory.Company.CompanyPolicy.DailyProducts; i++)
            {
                GetProduct(productName);              
            }
        }

        public void GetDailyProducts()
        {
            foreach (string productName in ProductQuantity.Keys.ToList<string>())
            {
                double dailyProduction;

                switch (productName)
                {
                    case "BlackChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.BlackChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "WhiteChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.WhiteChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "PlainMilkChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.MilkChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "AlmondMilkChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.AlmondMilkChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "HazelnutMilkChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.HazelnutMilkChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "ExperimentalProduct":
                        dailyProduction = Factory.Company.CompanyPolicy.ExperimentalPercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddExperimentalProduct()
        {
            if (SuppliesInKilo > 0)
            {
                ExperimentalSupplies += SuppliesInKilo;
                SuppliesInKilo = 0;
                try
                {
                    ProductQuantity.Add("ExperimentalProduct", 0);

                }
                catch (Exception)
                {
                    Console.WriteLine($"Factory already has Experimental Products.");
                }
            }
        }



    }
}
