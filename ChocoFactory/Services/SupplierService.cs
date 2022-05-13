﻿using ChocoFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    internal class SupplierService
    {

        public List<Offer> GetOffers(Factory factory)
        {
            List<Offer> offers = new List<Offer>();

            for (int i = 0; i < factory.Company.CompanyPolicy.NumberOfOffers; i++)
            {
                Supplier supplier = new Supplier();
                Offer offerNew = supplier.SendOffer(DataGenerator.PricePerKiloFake(), DataGenerator.QualityFake(), DataGenerator.QuantityFake());

                offers.Add(offerNew);
            }

            return offers;
        }

    }
}
