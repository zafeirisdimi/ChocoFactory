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
    public class WarehouseTests
    {
        [TestMethod()]
        public void WarehouseTest()
        {

        }

        [TestMethod()]
        public void DailyActionsTest()
        {

        }

        [TestMethod()]
        public void GetSuppliesTest()
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 0
            };

            int supplies = 100;

            warehouse.GetSupplies(supplies);

            Assert.AreEqual(supplies, warehouse.SuppliesInKilo);
        }

        [TestMethod()]
        public void SendSuppliesTest()
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 100
            };

            int supplies = 100;

            warehouse.SendSupplies(supplies);

            Assert.AreEqual(0, warehouse.SuppliesInKilo);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void GetProductTest(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            warehouse.GetProduct(productName);

            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(1, counter);
            Assert.AreEqual(1, warehouse.Products.Count);
            Assert.AreEqual(productName, warehouse.Products[0].Description);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void SendProductTest(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);
            warehouse.GetProduct(productName);

            var productInWarehouse = warehouse.Products[0];

            var productToSend = warehouse.SendProduct(productName);

            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, warehouse.Products.Count);
            Assert.AreEqual(productInWarehouse, productToSend);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void DontRemove_NotExpiredProductsTest(string productName)
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);
            warehouse.GetProduct(productName);

            PrivateObject privateObject = new PrivateObject(warehouse);

            privateObject.Invoke("RemoveExpiredProducts", yesterday);
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(1, counter);
            Assert.AreEqual(productName, warehouse.Products[0].Description);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RemoveExpiredProductsTest(string productName)
        {
            DateTime today = DateTime.Today;
            DateTime farFuture = today.AddDays(10000);

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);
            warehouse.GetProduct(productName);

            PrivateObject privateObject = new PrivateObject(warehouse);

            privateObject.Invoke("RemoveExpiredProducts", farFuture);
            
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, warehouse.Products.Count);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RefillProductTest(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            int dailyProducts = company.CompanyPolicy.Factory.DailyProducts;

            warehouse.RefillProduct(productName, 1);

            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(dailyProducts, counter);
        }


        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void GetDailyProductsTest(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            warehouse.GetDailyProducts();

            int products = 0;

            switch (productName)
            {
                case "BlackChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.BlackChocolatePercent);

                    break;
                case "WhiteChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.WhiteChocolatePercent);

                    break;
                case "PlainMilkChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.MilkChocolatePercent);

                    break;
                case "AlmondMilkChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                case "ExperimentalProduct":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.ExperimentalPercent);
                    break;
                default:
                    break;

            }

            Assert.AreEqual(products, warehouse.ProductQuantity[productName]);
        }

        [TestMethod()]
        public void DontAddExperimentalProductTest()
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 0
            };
            string productName = "ExperimentalProduct";

            warehouse.AddExperimentalProduct();

            Assert.IsFalse(warehouse.ProductQuantity.ContainsKey(productName), "The Dictionary contains experimental products");
        }

        [TestMethod()]
        public void AddExperimentalProductTest()
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 100
            };
            string productName = "ExperimentalProduct";

            warehouse.AddExperimentalProduct();

            Assert.IsTrue(warehouse.ProductQuantity.ContainsKey(productName), "The Dictionary does not contain experimental products");

            // Can I call other test methods to verify that they work with experimental products?
        }
    }
}