using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    abstract class MilkChocolate:Chocolate
    {

        //fields and properties

        //constructor(s)
        public MilkChocolate()
        {

        }


        public MilkChocolate(int productID, string description, DateTime productionDate, DateTime expirationDate, decimal price) :
            base(productID, description, productionDate, expirationDate, price)
        {

        }


        //methods
    }
}
