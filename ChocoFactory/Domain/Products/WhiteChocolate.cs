using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
     class WhiteChocolate : Chocolate
    {
        //fields and properties
        public override decimal Price { get; set; }
        
        
        
        //constructor(s)
        public WhiteChocolate()
        {

        }
        
        
        public WhiteChocolate(int productID, string description, DateTime productionDate, DateTime expirationDate, decimal price) :
            base(productID, description, productionDate, expirationDate, price)
        {

        }
        //methods
    }
}