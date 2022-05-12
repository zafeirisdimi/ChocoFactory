using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Domain;

namespace ChocoFactory.Services
{
    internal class Scenario
    {
        Company company = new Company(); // create Company object
        public void Initialization()
        {
            Factory factory = new Factory();
            company.Factories.Add(factory);
            
            Shop shop = new Shop();
            company.Shops.Add(shop);
        }

        public void AdvanceDay()
        {
            Shop.AdvanceDay(); // Calculate earnings and remaining products, refills stock if products 25% of total.
            Factory.Production.AdvanceDay(); // Produce 500 products
            Factory.Warehouse.AdvanceDay(); // Send 50% of products produced to shop
        }

        public void AdvanceYear()
        {
            Factory.Accounting.GetOffers();
            
            if (company.RevenueGoalAchieved)
            {
                Shop shop = new Shop();
                company.Shops.Add(shop);
            }
            
        }

        public bool CheckIfSecondTuesday()
        {
            throw new NotImplementedException();
        }

    }
}
