using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    internal class Company
    {

        private CustomerService customerService = new CustomerService();
        private int discountDayOccurences = 0;

        public decimal Capital { get; set; } = 1000000;
        public decimal Revenue { get; set; }
        public List<Factory> Factories { get; set; } = new List<Factory>();
        public List<Shop> Shops { get; set; } = new List<Shop>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public CompanyPolicy CompanyPolicy { get; set; } = new CompanyPolicy();
        public bool RevenueGoalAchieved
        {
            get { return Revenue > (decimal)CompanyPolicy.RevenueYearlyGoal * Revenue; }
        }

        public void Initialization()
        {
            Factory factory = new Factory();
            Factories.Add(factory);
            factory.Company = this;

            Shop shop = new Shop(this, factory);
            shop.Company = this;
            Shops.Add(shop);
            factory.Shops.Add(shop);
        }

        public void DayOne(DateTime currentDate)
        {
            foreach (Factory factory in Factories)
            {
                factory.Accounting.ReceiveOffers();
                factory.Accounting.SendOrder(factory.Accounting.BestOffer());
                factory.Warehouse.GetDailyProducts();
            }

            foreach (Shop shop in Shops)
            {
                shop.Discount = IsDiscountDay(currentDate) ? CompanyPolicy.ShopDiscount : 0;
                shop.RefillProducts();
                customerService.DailyPurchases(shop);
            }
        }

        public void DailyActions(DateTime currentDate)
        {
            Console.WriteLine($"Capital: {Capital}");
            Console.WriteLine($"Revenue: {Revenue}");
            foreach (Factory factory in Factories)
            {
                factory.Warehouse.DailyActions(currentDate);
            }

            foreach (Shop shop in Shops)
            {
                shop.Discount = IsDiscountDay(currentDate) ? CompanyPolicy.ShopDiscount : 0;
                customerService.DailyPurchases(shop);
                shop.DailyActions(currentDate);
            }
        }
        public void YearlyActions()
        {
            foreach (Factory factory in Factories)
            {
                factory.Warehouse.AddExperimentalProduct();
                factory.Accounting.ReceiveOffers();
                factory.Accounting.SendOrder(factory.Accounting.BestOffer());
            }

            if (RevenueGoalAchieved)
            {
                Shop shop = new Shop(this, DataGenerator.RandomFactory(this));
                Shops.Add(shop);
                Console.WriteLine("NEW SHOP!!");
            }

            // Update company capital, zero out the revenue.

        }

        public bool IsDiscountDay(DateTime currentDate)
        {
            if (currentDate.DayOfWeek == CompanyPolicy.DiscountDay)
                discountDayOccurences++;

            bool isDiscountDay = (discountDayOccurences == CompanyPolicy.DiscountDayOccurence);

            if (isDiscountDay || currentDate.Day == 1) // Reset counter every start of the month or every discount day.
                discountDayOccurences = 0;

            return isDiscountDay;
        }
    }
}
