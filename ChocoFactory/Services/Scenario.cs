using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    internal class Scenario
    {
        public void AdvanceDay()
        {
            Shop.AdvanceDay(); // Calculate earnings and remaining products, refills stock if products 25% of total.
            Factory.Production.AdvanceDay(); // Produce 500 products
            Warehouse.AdvanceDay(); // Send 50% of products produced to shop
        }


    }
}
