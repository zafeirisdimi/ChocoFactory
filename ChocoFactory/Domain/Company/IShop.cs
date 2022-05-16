using System;
using System.Collections.Generic;

namespace ChocoFactory.Domain
{
     interface IShop
    {
        
        decimal DailyEarnings { get; set; }
        Dictionary<string, int> DailyProductsSold { get; set; }
        double Discount { get; set; }
        List<Employee> Employees { get; set; }
        bool HasExperimentalProduct { get; }
        string Location { get; set; }
        List<Product> Products { get; set; }

        void DailyActions(DateTime currentDate);
        decimal SellProduct(string productName);
        decimal ServeCustomer(List<string> productsToSell);
    }
}