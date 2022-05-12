﻿using ChocoFactory.Interfaces;
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

        //methods
        public int SendSupplies(Order order)
        {
            //send the order form supplier to Production
            
            return supplies
        }

        public Offer SendOffer(decimal pricePerKilo, Quality quality, int suppliesKilos)
        {
            return new Offer(pricePerKilo, quality, suppliesKilos);
        }
        
    }
}
