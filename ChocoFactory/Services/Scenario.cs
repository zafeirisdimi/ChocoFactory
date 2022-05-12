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

        private int discountDayOccurences = 0;

        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; }

        private DateTime currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get { return currentDate; }
        }


        public Calendar Calendar { get; } = CultureInfo.InvariantCulture.Calendar;        

        public void Initialization()
        {
            Factory factory = new Factory();
            company.Factories.Add(factory);
            
            Shop shop = new Shop();
            company.Shops.Add(shop);
        }

        public void AdvanceTime()
        {
            while (StartingDate != EndingDate)
            {
                if (CurrentDate.Day == 1 && CurrentDate.Month == 1) // Do this on the first day of the year.
                {
                    YearlyActions();
                }

                DailyActions(); // Do this everyday.

                currentDate = Calendar.AddDays(CurrentDate, 1); // Advance Time by one day.
            }

        }

        public void DailyActions()
        {
            Shop.AdvanceDay(); // Calculate earnings and remaining products, refills stock if products 25% of total.
            Factory.Production.AdvanceDay(); // Produce 500 products
            Factory.Warehouse.AdvanceDay(); // Send 50% of products produced to shop

            Shop.Discount = company.CompanyPolicy.ShopDiscount;
        }

        public void YearlyActions()
        {
            Factory.Accounting.GetOffers();
            
            if (company.RevenueGoalAchieved)
            {
                Shop shop = new Shop();
                company.Shops.Add(shop);
            }
            
        }

        public bool CheckIfDiscountDay()
        {
            if (CurrentDate.DayOfWeek == company.CompanyPolicy.DiscountDay)
            {
                discountDayOccurences++;
            }

            bool isDiscountDay = (discountDayOccurences == company.CompanyPolicy.DiscountDayOccurence);

            if (isDiscountDay)
                discountDayOccurences = 0;

            return isDiscountDay;
        }

    }
}
