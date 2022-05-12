using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public abstract class Order
    {
        //properties of object Order
        public int OrderID { get; set; }
        public string ShortDescription { get; set; }

        public List<Product> Products = new List<Product>();
        public double FinalCost { get; set; }
        public string PayMethod { get; set; }



       
        //custom constructor
        protected Order(int orderID, string shortDescription, List<Product> products, double finalCost, string payMethod)
        {
            OrderID = orderID;
            ShortDescription = shortDescription;
            Products = products;
            FinalCost = finalCost;
            PayMethod = payMethod;
        }

        


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //methods


    }
}
