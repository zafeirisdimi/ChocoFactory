using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChocoFactory.Domain;
using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain.Tests
{
    [TestClass()]

    public class AccountingTests
    {
        [TestMethod()]
        public void ReceiveOffersTest()
        {
            Company company = new Company();    
            Factory factory = new Factory(company);
            Accounting accounting = new Accounting(factory);

            accounting.ReceiveOffers();

            Assert.AreEqual(company.CompanyPolicy.NumberOfOffers, accounting.AvailableOffers.Count);
        }

        [TestMethod()]
        public void SendOrderTest()
        {
            Company company = new Company()
            {
                Revenue = 100m
            };
            Factory factory = new Factory(company);
            Accounting accounting = new Accounting(factory);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 0
            };

            factory.Warehouse = warehouse;
            factory.Accounting = accounting;

            Offer offer = new Offer(1, Quality.Low, 100, new Supplier());

            accounting.SendOrder(offer);

            Assert.AreEqual(warehouse.SuppliesInKilo, offer.Quantity);
            Assert.AreEqual(offer.TotalCost, 100);
            Assert.AreEqual(0, company.Revenue);
        }

        [TestMethod()]
        public void OfferValueTest()
        {
            Offer offer1 = new Offer(10, Quality.Medium, 100, new Supplier());
            Offer offer2 = new Offer(10, Quality.Low, 100, new Supplier());

            Company company = new Company();
            Factory factory = new Factory(company);
            Accounting accounting = new Accounting(factory);

            double value1 = accounting.OfferValue(offer1);
            double value2 = accounting.OfferValue(offer2);

            Assert.IsTrue(value1 > value2, "The offer2 had higher value than offer1.");
        }

        [TestMethod()]
        public void DiffPricePerKilo_SameQuality_BestOfferTest()
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            Accounting accounting = new Accounting(factory);

            Supplier supplier = new Supplier();

            Offer offer1 = new Offer(5, Quality.Medium, 100, supplier);
            Offer offer2 = new Offer(10, Quality.Medium, 100, supplier);
            Offer offer3 = new Offer(15, Quality.Medium, 100, supplier);

            accounting.AvailableOffers = new List<Offer>()
            {
                offer1,
                offer2,
                offer3
            };

            Assert.AreEqual(offer1, accounting.BestOffer);
        }

        [TestMethod()]
        public void DiffQuality_SamePricePerKilo_BestOfferTest()
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            Accounting accounting = new Accounting(factory);

            Supplier supplier = new Supplier();

            Offer offer1 = new Offer(5, Quality.High, 100, supplier);
            Offer offer2 = new Offer(5, Quality.Medium, 100, supplier);
            Offer offer3 = new Offer(5, Quality.Low, 100, supplier);

            accounting.AvailableOffers = new List<Offer>()
            {
                offer1,
                offer2,
                offer3
            };

            Assert.AreEqual(offer1, accounting.BestOffer);
        }

    }
}