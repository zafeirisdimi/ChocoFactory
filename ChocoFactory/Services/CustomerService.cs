using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    internal class CustomerService
    {
        Random rnd = new Random();
        private int maxProducts = 50;
        private int maxCustomers = 100;

        private string[] productNames = new string[]
        {
            "WhiteSchocolate",
            "BlackSchocolate",
            "PlainMilkSchocolate",
            "AlmondMilkSchocolate",
            "HazelnutMilkSchocolate"
        };

        public void BuyRandomProducts()
        {
            int randomNumberOfProducts = rnd.Next(maxProducts + 1);

            for (int i = 0; i < randomNumberOfProducts; i++)
            {
                string randomProduct = productNames[rnd.Next(productNames.Length)];
                Shop.SellProduct(randomProduct);
            }
        }

        public void RandomCustomers()
        {
            int randomNumberOfCustomers = rnd.Next(maxCustomers + 1);

            for (int i = 0; i < randomNumberOfCustomers; i++)
            {
                BuyRandomProducts();
            }
        }

    }
}
