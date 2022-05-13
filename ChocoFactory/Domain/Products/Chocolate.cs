using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public abstract class Chocolate: Product 
    {
        //fields and properties
        //public override decimal Price { get; set; }
        
        
        //constructor(s)
        public Chocolate()
        {

        }


        public Chocolate(int productID, string description, DateTime productionDate, DateTime expirationDate, decimal price):
            base(productID, description, productionDate, expirationDate, price)
        {

        }
        
        //methods
    }
}
