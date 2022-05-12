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
        public Supplier Supplier { get; set; }

        //properties

        public Dictionary<string, int> ProductQuantity { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteChocolate" , 0},
            {"BlackChocolate" , 0},
            {"PlainMilkChocolate" , 0},
            {"AlmondMilkChocolate" , 0},
            {"HazelnutMilkChocolate" , 0}
        };
        public int SuppliesInKilo { get; set; }
        public List<Product> Products { get; set; }

        //methods
        public void GetSupplies()
        {
            SuppliesInKilo += Supplier.SendSupplies();
        }
        public int SendSupplies(int kilos)//called from Production
        {
            SuppliesInKilo -= kilos;
            return kilos;
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
            if (SuppliesInKilo * 0.1 <= Supplier.Offer.Quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void RemoveExpiredProducts()
        {
            foreach (Product product in Products)
            {
                if (product.ExpirationDate > DateTime.Now)
                {
                    ProductQuantity[product.Description]--;
                    Products.Remove(product);
                }
            }
        }
        public void DailyActions()
        {
            if (AreSuppliesLow())
            {
                Factory.Accounting.SendOrder(Supplier.Offer);
                GetSupplies();
            }
            RefillProducts("BlackChocolate", Factory.Company.CompanyPolicy.BlackChocolatePercent);
            RefillProducts("WhiteChocolate", Factory.Company.CompanyPolicy.WhiteChocolatePercent);
            RefillProducts("PlainMilkChocolate", Factory.Company.CompanyPolicy.MilkChocolatePercent);
            RefillProducts("AlmondMilkChocolate", Factory.Company.CompanyPolicy.AlmondMilkChocolatePercent);
            RefillProducts("HazelnutMilkChocolate", Factory.Company.CompanyPolicy.HazelnutMilkChocolatePercent);
        }

        public void RefillProducts(string productName, double policyPercentage)
        {
            for (int i = 1; i <= policyPercentage * 100; i++)
            {
                GetProduct(productName);
               
            }
        }


    }
}
