using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    class Warehouse : Department
    {

        //properties
        public Dictionary<string, int> ProductQuantity { get; set; } = new Dictionary<string, int>() 
        {
            {"WhiteSchocolate" , 0},
            {"BlackSchocolate" , 0},
            {"MilkSchocolate" , 0}
        };
        public int SuppliesInKilo { get; set; }
        List<Product> products;

        public GetSupplies(Supplies supplies) 
        {
            //Supplies.SendSupplies()
        }
        public int SendSupplies(int kilos)//called from Production
        {
            //SuppliesInKilo -= kilos;
            //return
        }
        public void GetProduct(string productName)
        {
            
            //Production.CreateProduct();
            //products.Add(productName);
            //Update Dictionary;
        }
        public Product SendProduct(string productName)
        {
            //products.Remove()
            //Update Dictionary;
            //return product;
        }
        public CheckSupplies()//check for 10% of supplies
        {
            //if supplies < 10% of supplies,
        }

    }
}
