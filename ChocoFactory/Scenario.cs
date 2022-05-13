using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Domain;

namespace ChocoFactory.Services
{
    internal class Scenario
    {
        Company company = new Company(); // create Company object
        CustomerService customerService = new CustomerService();

        private int discountDayOccurences = 0;

        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; }

        private DateTime currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get { return currentDate; }
        }


        public Calendar Calendar { get; } = CultureInfo.InvariantCulture.Calendar;

        public void Start()
        {
            Initialization();
            AdvanceTime();
        }


        public void Initialization()
        {
            Factory factory = new Factory();
            company.Factories.Add(factory);

            Shop shop = new Shop(company, factory);
            company.Shops.Add(shop);

            factory.Shops.Add(shop);
        }

        public void AdvanceTime()
        {
            while (CurrentDate != EndingDate)
            {
                if ((CurrentDate.Day == 1 && CurrentDate.Month == 1) || CurrentDate == StartingDate) // Do this on the first day of the year.
                {
                    YearlyActions();
                }

                DailyActions(); // Do this everyday.

                currentDate = Calendar.AddDays(CurrentDate, 1); // Advance Time by one day.
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
            foreach (Factory factory in company.Factories)
            {
                while (factory.Warehouse.SuppliesInKilo >= factory.Production.ProductionPolicy.ExperimentalChocolateSupplies)
                {
                    factory.Shops
                }
                

            }
            foreach (Factory factory in company.Factories)
            {
                factory.Accounting.ReceiveOffers();
            }

            if (company.RevenueGoalAchieved)
            {
                
                Shop shop = new Shop(company, DataGenerator.RandomFactory(company));
                company.Shops.Add(shop);
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

    }
}
