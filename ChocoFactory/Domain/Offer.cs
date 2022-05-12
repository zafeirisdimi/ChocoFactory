using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    //object oofer form Supplier
    class Offer
    {
        //properties
        public decimal PricePerKilo { get; set; }
        public Quality Quality { get; set; }
        public int Quantity { get; set; }

        public Offer()
        {

        }

        public Offer(decimal pricePerKilo, Quality quality, int quantity)
        {
            PricePerKilo = pricePerKilo;
            Quality = quality;
            Quantity = quantity;
        }



    }
}
