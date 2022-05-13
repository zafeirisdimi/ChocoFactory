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
            {"HazelnutMilkChocolate" , 0},
            {"ExperimentalProduct", 0 }
        };
        public int SuppliesInKilo { get; set; }

        public Warehouse(Factory factory)
        {
            Factory = factory;
        }


        //methods
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

        public bool AreSuppliesLow()//check for 10% of supplies
        {
            return SuppliesInKilo <= Factory.Accounting.LastOrder.Quantity * Factory.Company.CompanyPolicy.LowSuppliesThresholdPercent;
        }

        private void RemoveExpiredProducts(DateTime currentDate)
        {
            foreach (Product product in Products)
            {
                if (product.ExpirationDate > currentDate)
                {
                    ProductQuantity[product.Description]--;
                    Products.Remove(product);
                }
            }
        }
        public void DailyActions(DateTime currentDate)
        {
            RemoveExpiredProducts(currentDate);
            if (AreSuppliesLow())
            {
                Factory.Accounting.SendOrder(Factory.Accounting.LastOrder);
            }
            GetDailyProducts();
        }

        public void RefillProduct(string productName, double policyPercentage)
        {
            for (int i = 1; i <= policyPercentage * Factory.Company.CompanyPolicy.DailyProducts; i++) // I don't think this will work.
            {
                GetProduct(productName);              
            }
        }

        public void GetDailyProducts()
        {
            RefillProduct("BlackChocolate", Factory.Company.CompanyPolicy.BlackChocolatePercent);
            RefillProduct("WhiteChocolate", Factory.Company.CompanyPolicy.WhiteChocolatePercent);
            RefillProduct("PlainMilkChocolate", Factory.Company.CompanyPolicy.MilkChocolatePercent);
            RefillProduct("AlmondMilkChocolate", Factory.Company.CompanyPolicy.AlmondMilkChocolatePercent);
            RefillProduct("HazelnutMilkChocolate", Factory.Company.CompanyPolicy.HazelnutMilkChocolatePercent);
        }

        



    }
}
