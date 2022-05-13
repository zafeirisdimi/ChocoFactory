using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain.Products
{
    class ExperimentalProduct: Product
    {

        //fields and properties
        public virtual decimal Price { get; set; }


        //constructor(s)
        public ExperimentalProduct()
        {

        }

        public ExperimentalProduct(int productID, string description, DateTime productionDate, DateTime expirationDate, decimal price) :
            base(productID, description, productionDate, expirationDate, price)
        {


        }

        //methods
    }
}
