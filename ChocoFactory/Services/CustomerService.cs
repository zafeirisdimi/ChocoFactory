using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Domain;

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

        private void DailyPurchases(Shop shop)
        {
            int numberOfCustomers = rnd.Next(maxCustomers + 1);

            for (int i = 0; i < numberOfCustomers; i++)
            {
                List<string> products = ProductsToBuy();
                shop.ServeCustomer(products);
            }
        }


        private List<string> ProductsToBuy()
        {
            int randomNumberOfProducts = rnd.Next(maxProducts + 1);
            List<string> products = new List<string>();

            for (int i = 0; i < randomNumberOfProducts; i++)
            {
                string randomProduct = productNames[rnd.Next(productNames.Length)];
                products.Add(randomProduct);
            }

            return products;
        }


    }
}
