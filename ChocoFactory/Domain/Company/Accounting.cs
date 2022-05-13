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


        public Accounting(Factory factory)
        {
            Factory = factory;
        }

        //methods
        public void ReceiveOffers()
        {
            AvailableOffers = new List<Offer>(supplierService.Offers(Factory));
            Console.WriteLine("[New offer from Supplier is delivered !!!]");
         }

        public  Order SendOrder(Offer offer)
        {
            Offer bestOffer = BestOffer();
            //send this offer as order to supplier
            Order order = new Order(bestOffer, Factory);
            
            order.Supplier.SendSupplies(order);
            
            LastOrder = order;
            LastSupplier = order.Supplier;

            Console.WriteLine("[Send order!!!]");
            return order;
        }

        public Offer BestOffer()
        {
            double bestValue = 0;
            Offer bestOffer = null;

            foreach (Offer offer in AvailableOffers)
            {
                double value = OfferValue(offer);

                if(value > bestValue)
                {
                    bestValue = value;
                    bestOffer = offer;
                }
            }
            return bestOffer;
        }

        private double OfferValue(Offer offer)
        {
            int quality = (int)offer.Quality;
            double pricePerKilo = (double)offer.PricePerKilo;
            return quality / pricePerKilo;
        }
    }
}
