using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    class Supplier
    {
        //properties
        public int ID { get; set; }// SupplierID
        public Offer Offer { get; set; }// object Offer 
        public int OrderID { get; } // the OrderID from the Accounting deparment of our Factory
        public static int chancesToOffer = 3;

        //custom constructor
        public Supplier(int id,Offer offer, int orderID)
        {
            ID = id;
            Offer = offer;
            OrderID = orderID;
        }

        //methods
        public int SendSupplies(Order order)
        {
            //send the order form supplier to Production
            
            return supplies
        }
        public static Offer SendOffer()
        {
            do
            {
                //create new (decimal pricePerKilo, Quality quality, int quantity) with random data
                Offer offer = new Offer(decimal pricePerKilo, Quality quality, int quantity);
                //until the chancesToOffer = 0;
                return offer;
            } while (chancesToOffer == 3);
            
        }
        
    }
}
