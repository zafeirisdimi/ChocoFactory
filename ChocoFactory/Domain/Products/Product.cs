using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public abstract class Product
    {
        

        //properties
        public int ProductID { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }

        //constructor
        protected Product(int productID, string description, DateTime productionDate, DateTime expirationDate, decimal price)
        {
            ProductID = productID;
            Description = description;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Price = price;
        }

        //methods


    }
}
