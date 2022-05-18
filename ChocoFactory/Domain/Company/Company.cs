using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{


    public class Company

    {
        public decimal Capital { get; private set; } = 1000000;
        public decimal Revenue { get; set; }
        public List<Factory> Factories { get; set; } = new List<Factory>();
        public List<Shop> Shops { get; set; } = new List<Shop>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public CompanyPolicy CompanyPolicy { get; set; } = new CompanyPolicy();
        public bool RevenueGoalAchieved
        {
            get { return Revenue > (decimal)CompanyPolicy.RevenueYearlyGoal * Revenue; }
        }

        public Company()
        {
            Factory factory = new Factory(this);
            factory.OpeningActions();
            Factories.Add(factory);
          
            Shop shop = new Shop(this, factory);
            Shops.Add(shop);
            shop.RefillStock();
            factory.Shops.Add(shop);
        }
        

        public void DailyActions(DateTime currentDate)
        {
            Console.WriteLine($"Capital: {Capital}");
            Console.WriteLine($"Revenue: {Revenue}");

            foreach (Factory factory in Factories)
            {
                factory.DailyActions(currentDate);
            }

            foreach (Shop shop in Shops)
            {
                shop.DailyActions(currentDate);
            }
        }

        public void YearlyActions()
        {
            foreach (Factory factory in Factories)
            {
                factory.YearlyActions();
            }

            if (RevenueGoalAchieved)
            {
                Shop shop = new Shop(this, DataGenerator.RandomFactory(this));
                shop.RefillStock();
                Shops.Add(shop);
                Console.WriteLine("NEW SHOP!!");
            }

            Capital += Revenue;
            Revenue = 0;
        }
    }
}
