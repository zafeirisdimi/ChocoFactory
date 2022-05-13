using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Domain;
using ChocoFactory.Services;

namespace ChocoFactory
{
    internal class Scenario
    {
        Company company = new Company(); // create Company object
        CustomerService customerService = new CustomerService();

        private int discountDayOccurences = 0;

        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; } = new DateTime(2025, 5, 30);

        private DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime CurrentDate
        {
            get { return currentDate; }
        }


        public Calendar Calendar { get; } = CultureInfo.InvariantCulture.Calendar;

        public void Start()
        {
            Initialization();
            AdvanceTime();

            Console.WriteLine("End of Scenario");

            Console.WriteLine($"Final Company Capital: {company.Capital}");
            Console.WriteLine($"Final Company Revenue: {company.Revenue}");
        }

        public void Initialization()
        {
            Factory factory = new Factory();
            company.Factories.Add(factory);
            factory.Company = company;

            Shop shop = new Shop(company, factory);
            shop.Company = company;
            company.Shops.Add(shop);
            factory.Shops.Add(shop);
        }

        public void AdvanceTime()
        {
            while (CurrentDate != EndingDate)
            {
                if (CurrentDate.Date == StartingDate.Date)
                {
                    DayOne();
                }

                if (CurrentDate.Day == 1 && CurrentDate.Month == 1) // Do this on the first day of the year.
                {
                    YearlyActions();
                }

                DailyActions(); // Do this everyday.

                currentDate = Calendar.AddDays(CurrentDate, 1); // Advance Time by one day.

                Console.WriteLine($"End of day {currentDate}\n");
            }

        }

        public void DailyActions()
        {
            foreach (Factory factory in company.Factories)
            {
                factory.Warehouse.DailyActions(currentDate);
            }

            foreach (Shop shop in company.Shops)
            {
                shop.Discount = IsDiscountDay() ? company.CompanyPolicy.ShopDiscount : 0;
                customerService.DailyPurchases(shop);
                shop.DailyActions(CurrentDate);
            }
        }

        public void YearlyActions()
        {
            CreateAndDistributeExperimentalProducts();


            foreach (Factory factory in company.Factories)
            {
                factory.Accounting.ReceiveOffers();
                factory.Accounting.SendOrder(factory.Accounting.BestOffer());
            }

            if (company.RevenueGoalAchieved)
            {
                
                Shop shop = new Shop(company, DataGenerator.RandomFactory(company));
                company.Shops.Add(shop);
            }
        }

        public void DayOne()
        {
            foreach (Factory factory in company.Factories)
            {
                factory.Accounting.ReceiveOffers();
                factory.Accounting.SendOrder(factory.Accounting.BestOffer());
                factory.Warehouse.GetDailyProducts();
            }

            foreach (Shop shop in company.Shops)
            {
                shop.Discount = IsDiscountDay() ? company.CompanyPolicy.ShopDiscount : 0;
                shop.RefillProducts();
                customerService.DailyPurchases(shop);
            }


        }

        public bool IsDiscountDay()
        {
            if (CurrentDate.DayOfWeek == company.CompanyPolicy.DiscountDay)
            {
                discountDayOccurences++;
            }

            bool isDiscountDay = (discountDayOccurences == company.CompanyPolicy.DiscountDayOccurence);

            if (isDiscountDay || CurrentDate.Day == 1)
                discountDayOccurences = 0;

            return isDiscountDay;
        }

        public void CreateAndDistributeExperimentalProducts()
        {
            foreach (Factory factory in company.Factories)
            {
                while (factory.Warehouse.SuppliesInKilo >= factory.Production.ProductionPolicy.ExperimentalChocolateSupplies)
                {
                    factory.Warehouse.GetProduct("ExperimentalProduct");

                }
                while (factory.Warehouse.Products.Any(x => x.Description == "ExperimentalProduct"))
                {
                    foreach (Shop shop in factory.Shops)
                    {
                        shop.ReceiveProduct("ExperimentalProduct");
                    }

                }



            }
        }

    }
}
