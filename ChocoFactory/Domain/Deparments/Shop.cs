using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Shop
    {
        //properties
        List<Product> ProductsOnSale;
        public Dictionary<string, int> ProductQuantity { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteSchocolate" , 0},
            {"BlackSchocolate" , 0},
            {"MilkSchocolate" , 0}
        };
        List<Customer> Customers = new List<Customer>();


        //methods
        public SellProduct(string productName)
        {
            //Update productsSale
            //Update ProductQuantity
            //
        }
        public void ReceiveProduct(Product p)//
        {
            //if productsQuantity is low,
            Factory.Warehouse.SendProduct();
            //else{}
        }

        public void CheckProduct()//
        {

        }
    }
}
