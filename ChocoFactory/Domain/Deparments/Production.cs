using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    
    class Production: Department
    {
        public Factory Factory { get; set; }


        public Product CreateProduct(string productName)
        {

            switch (productName)
            {
                case "BlackChocolate": return new BlackChocolate();
                case "WhiteChocolate": return new WhiteChocolate();
                case "PlainMilkChocolate": return new PlainMilkChocolate();
                case "AlmondMilkChocolate": return new AlmondMilkChocolate();
                case "HazelnutMilkChocolate": return new HazelnutMilkChocolate();
                default:
                    Console.WriteLine("Error creating product");
                    return null;
               
            }
            
        }



    }
}
