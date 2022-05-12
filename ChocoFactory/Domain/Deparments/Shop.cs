using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Shop
    {
        public Company Company { get; set; }
        public double Discount { get; set; }
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
        public double DailyEarnings { get; set; }



        //methods
        public void SellProduct(string productName)
        {
            Product productToSell = Products.Find(x => x.Description == productName);
            DailyEarnings += productToSell.Price;
            Products.Remove(productToSell);
            DailyProductsSold[productName]++;

        }

        public void AdvanceDay()
        {
            DailyReport();
            SendDailyEarnings();
            DailyEarnings = 0;
            foreach (var productType in DailyProductsSold)
            {
                productType.Value = 0;
            }
            RemoveExpiredProducts();
            if (IsProductQuantityLow())
            {
                RefillProducts();
            }

        }

        private string DailyReport()
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
            return Company.Factory.Warehouse.SendProduct();
        }
        private void RemoveExpiredProducts()
        {
            foreach (Product product in Products)
            {
                if (product.ExpirationDate > DateTime.Now)
                {
                    Products.Remove(product);
                }
            }
        }
    }
}
