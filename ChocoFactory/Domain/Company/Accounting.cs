using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Services;

namespace ChocoFactory.Domain
{
    class Accounting
    {
        // fields
        SupplierService supplierService= new SupplierService();

        //properties
        public Factory Factory { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();//list of possible employees of this deparment
        public List<Offer> AvailableOffers { get; set; } = new List<Offer>();// list of available offers of possible suppliers
        public Supplier LastSupplier { get; set; }// the last supplier that send us offer
        public Order LastOrder { get; set; }

        //methods
        public void ReceiveOffers()
        {
            AvailableOffers = new List<Offer>(supplierService.Offers(Factory));
            Console.WriteLine("[New offer from Supplier is delivered !!!]");
         }

        public  Order SendOrder(Offer offer)
        {
            Offer bestOffer = CheckBestOffer();
            //send this offer as order to supplier
            Order order = new Order(bestOffer, Factory);

            order.Supplier.SendSupplies(order);
           
            LastOrder = order;
            LastSupplier = order.Supplier;

            Console.WriteLine("[Send order!!!]");
            return order;
        }

        public Offer CheckBestOffer()
        {
            Offer offer0 = AvailableOffers[0];
            
            foreach (var offer in AvailableOffers)//Criteria for best offer(lower price and higher quality)
            {
                if ((offer.PricePerKilo < offer0.PricePerKilo) && (offer.Quality > offer0.Quality)) // This only checks of the price as it is.
                    offer0 = offer;
            }
            Console.WriteLine("[Check for the best price Offer is completed!]");
            return offer0;
        }

        private double OfferValue(Offer offer)
        {
            int quality = (int)offer.Quality;
            double pricePerKilo = (double)offer.PricePerKilo;
            return quality / (quality + pricePerKilo);
        }
    }
}
