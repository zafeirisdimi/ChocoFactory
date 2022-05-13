using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    class Order : Offer
    {

        public Order (decimal pricePerKilo, Quality quality, int quantity, Supplier supplier) : base (pricePerKilo, quality, quantity, supplier)
        {

        }

        public Order(Offer offer)
        {
            this.PricePerKilo = offer.PricePerKilo; 
            this.Quality = offer.Quality;
            this.Quantity = offer.Quantity;
            this.Supplier = offer.Supplier;
        }
    }
}
