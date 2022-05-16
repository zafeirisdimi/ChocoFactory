using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Services;

namespace ChocoFactory.Domain
{
    class Accounting : Department
    {
        // fields
        readonly SupplierService supplierService= new SupplierService();
        private Offer bestOffer;

        // Properties
        public Factory Factory { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();//list of possible employees of this deparment.
        public List<Offer> AvailableOffers { get; set; } = new List<Offer>();// list of available offers of possible suppliers
        public Offer BestOffer
        {
            get
            {
                double bestValue = 0;

                foreach (Offer offer in AvailableOffers)
                {
                    double value = OfferValue(offer);

                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestOffer = offer;
                    }
                }
                return bestOffer;
            }
        }
        public Supplier LastSupplier { get; set; }// the last supplier that send us offer
        public Order LastOrder { get; set; }
        
        // Constructor
        public Accounting(Factory factory)
        {
            Factory = factory;
        }

        //methods
        public void ReceiveOffers()
        {
            AvailableOffers = new List<Offer>(supplierService.Offers(Factory));
            Console.WriteLine("The offers from Suppliers are delivered.");
         }

        public  Order SendOrder(Offer offer)
        {
            Order order = new Order(BestOffer, Factory);
            
            order.Supplier.SendSupplies(order);

            Factory.Company.Revenue -= order.PricePerKilo;

            LastOrder = order;
            LastSupplier = order.Supplier;

            Console.WriteLine("[Send order!!!]");
            return order;
        }

        private double OfferValue(Offer offer)
        {
            int quality = (int)offer.Quality;
            double pricePerKilo = (double)offer.PricePerKilo;
            return quality / pricePerKilo;
        }
    }
}
