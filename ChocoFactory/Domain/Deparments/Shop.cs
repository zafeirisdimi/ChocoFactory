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
        public void SellProduct(string productName)
        {
            Product productToSell = Products.Find(x => x.Description == productName);
            DailyEarnings += (decimal)productToSell.Price;
            Products.Remove(productToSell);
            DailyProductsSold[productName]++;

        }

        public void DailyActions(DateTime date)
        {
            DailyReport();
            SendDailyEarnings();
            DailyEarnings = 0;
            foreach (var productType in DailyProductsSold)
            {
                productType.Value = 0;
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



        private bool IsProductQuantityLow()//
        {
            if (Products.Count <= 62)
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
                Products.Add(newProduct);
            } while (Products.Count < 250);
        }

        private Product ReceiveProduct()//
        {
            return Company.Factory.Warehouse.SendProduct();
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
    }
}
