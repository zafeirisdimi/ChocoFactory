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

        private int expectedValueProducts = 10;
        private int varianceProducts = 10;
        private int maxProducts = 50;

        //private int GaussianDistribution(int max, int expectedValue, int variance)
        //{
        //    int randomNumber = rnd.Next();
        //    int test = max * Math.Exp(-Math.Pow(randomNumber - expectedValue, 2) / (2 * Math.Pow(variance, 2)));
        //}




        string[] productNames = new string[]
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
    }
}
