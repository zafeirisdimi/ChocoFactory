﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    class Accounting
    {
        //properties
        List<Employee> Employees = new List<Employee>();//list of possible employees of this deparment
        List<Offer> AvailableOffers = new List<Offer>();// list of available offers of possible suppliers
        public Supplier LastSupplier { get; set; }// the last supplier that send us offer
        public Order LastOrder { get; set; }
        public Factory Factory { get; set; }

        //methods
        public void ReceiveOffers()
        {
            //service getSupplier

            for (int i = 0; i < Factory.Company.CompanyPolicy.NumberOfOffers; i++)
            {
                Supplier supplier = new Supplier();
                Suppliers.Add(supplier);
            }

            Offer offerNew = Supplier.SendOffer();
            AvailableOffers.Add(offerNew);
            Console.WriteLine("[New offer from Supplier is delivered !!!]");

            //add to list(offer)
         }

        public  Order SendOrder(Offer offer)
        {
            AvailableOffers.Add(offer);
            //CheckBestOffer(). if the order is perfect
            var offerToSupplier = CheckBestOffer();
            //send this offer as order to supplier
            Order order = new OrderToSupplier(offerToSupplier.PricePerKilo, offerToSupplier.Quality, offerToSupplier.Quantity);
            Console.WriteLine("[Send order!!!]");
            return order;
        }

        public Offer CheckBestOffer()
        {
            //take the best offer base of PricePerKilo(min)
            if (AvailableOffers.Count == 0)
            {
                throw new InvalidOperationException("[Empty list of available offers]");
            }
            Offer offer0 = AvailableOffers[0];
            
            foreach (var offer in AvailableOffers)//Criteria for best offer(lower price and higher quality)
            {
                if ((offer.PricePerKilo < offer0.PricePerKilo) && (offer.Quality > offer0.Quality)) 
                    offer0 = offer;
            }
            Console.WriteLine("[Check for the best price Offer is completed!]");
            return offer0;
        }
    }
}