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
    public class ProductionTests
    {
        [TestMethod()]
        public void CreateProductTestWhite() // Test for white chocolate
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Production production = new Production(factory);

            string productName = "WhiteChocolate";

             IChocolate productCreated = (IChocolate)production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.Pricing.WhiteChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestBlack() // Test for black chocolate
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Production production = new Production(factory);

            string productName = "BlackChocolate";

            IChocolate productCreated = (IChocolate)production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.Pricing.BlackChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestMilk() // Test for milk chocolate
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Production production = new Production(factory);

            string productName = "PlainMilkChocolate";

            IChocolate productCreated = (IChocolate)production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.Pricing.MilkChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestAlmondMilk() // Test for almond milk chocolate
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Production production = new Production(factory);

            string productName = "AlmondMilkChocolate";

            IChocolate productCreated = (IChocolate)production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.Pricing.AlmondMilkChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestHazelnutMilk() // Test for halzenut milk chocolate
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Production production = new Production(factory);

            string productName = "HazelnutMilkChocolate";

            IChocolate productCreated = (IChocolate)production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.Pricing.HazelnutMilkChocolatePrice, productCreated.Price);
        }
    }
}