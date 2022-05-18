using ChocoFactory.Interfaces;
using ChocoFactory.Service;
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
        //properties
        private readonly CustomerService customerService = new CustomerService();
        private int discountDayOccurences = 0;

        public Company Company { get; set; }
        public Factory Factory { get; set; }
        public double Discount { get; set; } = 0;
        public List<IProductModel> Products { get; set; } = new List<IProductModel>();

        public List<IEmployeeModel> Employees { get; set; }

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

        public bool HasExperimentalProduct
        {
            get { return Products.Any(x => x.Description == "ExperimentalProduct"); }
        }


        // Constructor

        public Shop(Company company,Factory factory)
        {
            Company = company;
            Factory = factory;
            Employees = MockHelper.EmployeesMockList(); // bring a mock list of employee in Shop
            RefillStock();
        }

        //methods
        public void DailyActions(DateTime currentDate)
        {
            Discount = IsDiscountDay(currentDate) ? Company.CompanyPolicy.ShopDiscount : 0;

            customerService.DailyPurchases(this);

            SendDailyEarnings();

            ResetDailyProductsSold();

            RemoveExpiredProducts(currentDate);

            RefillStock();
        }

        private void ResetDailyProductsSold()
        {
            foreach (var productType in DailyProductsSold.Keys.ToList<string>())
            {
                DailyProductsSold[productType] = 0;
            }
        }

        private bool IsDiscountDay(DateTime currentDate)
        {
            if (currentDate.DayOfWeek == Company.CompanyPolicy.DiscountDay)
                discountDayOccurences++;

            bool isDiscountDay = (discountDayOccurences == Company.CompanyPolicy.DiscountDayOccurence);

            if (isDiscountDay || currentDate.Day == 1) // Reset counter every start of the month or every discount day.
                discountDayOccurences = 0;

            return isDiscountDay;
        }

        public decimal SellProduct(string productName)
        {
            IProductModel productToSell = Products.Find(x => x.Description == productName);
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
                try
                {
                    totalCost += SellProduct(product);
                }
                catch (Exception)
                {
                    Console.WriteLine("The shop did not have the product.");
                }
            }

            if (HasExperimentalProduct && totalCost >= Company.CompanyPolicy.GiftMinimumPrice)
            {
                Products.Remove(Products.Find(x=>x.Description=="ExperimentalProduct"));
            }
            return totalCost;
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
            DailyEarnings = 0;
        }

        private bool IsProductQuantityLow(string productName)
        {
            int stockProducts = 0;
            switch (productName)
            {
                case "BlackChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }
            int productCounter = Products.Where(x => x.Description == productName).Count();

            return productCounter < stockProducts;
        }

        private void RefillProduct(string productName)
        {
            int productMaxCapacity = 0;

            switch (productName)
            {
                case "BlackChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.ShopStockSize * Company.CompanyPolicy.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }

            int productsInStock = Products.Where(x => x.Description == productName).Count();
            while (productsInStock < productMaxCapacity)
            {
                ReceiveProduct(productName);
                productsInStock++;
            }      
        }

        private void RefillStock()
        {
            foreach (string productName in DailyProductsSold.Keys.ToList<string>())
            {
                if (IsProductQuantityLow(productName))
                {
                    RefillProduct(productName);
                }
            }
        }

        private void ReceiveProduct(string productName)
        {
            IProductModel newProduct = Factory.Warehouse.SendProduct(productName);
            Products.Add(newProduct);          
        }

        private void RemoveExpiredProducts(DateTime currentDate)
        {
            Product product;
            for (int i = 0; i < Products.Count; i++)
            {
                product = Products[i];
                if (product.ExpirationDate > currentDate)
                {
                    Products.Remove(product);
                }
            }
        }
    }
}
