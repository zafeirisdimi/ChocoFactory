using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChocoFactory.Domain;
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
            Company company = new Company();
            Factory factory = new Factory(company);
            Production production = new Production(factory);

            string productName = "WhiteChocolate";

            Product productCreated = production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.WhiteChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestBlack() // Test for black chocolate
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            Production production = new Production(factory);

            string productName = "BlackChocolate";

            Product productCreated = production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.BlackChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestMilk() // Test for milk chocolate
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            Production production = new Production(factory);

            string productName = "PlainMilkChocolate";

            Product productCreated = production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.MilkChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestAlmondMilk() // Test for almond milk chocolate
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            Production production = new Production(factory);

            string productName = "AlmondMilkChocolate";

            Product productCreated = production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.AlmondMilkChocolatePrice, productCreated.Price);
        }

        [TestMethod()]
        public void CreateProductTestHazelnutMilk() // Test for halzenut milk chocolate
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            Production production = new Production(factory);

            string productName = "HazelnutMilkChocolate";

            Product productCreated = production.CreateProduct(productName);

            Assert.AreEqual(productName, productCreated.Description);
            Assert.AreEqual(production.Factory.Company.CompanyPolicy.HazelnutMilkChocolatePrice, productCreated.Price);
        }
    }
}