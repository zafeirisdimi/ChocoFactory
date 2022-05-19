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
    public class ShopTests
    {
        [TestMethod()]
        public void ShopTest()
        {

        }

        [TestMethod()]
        public void DailyActionsTest()
        {

        }

        [TestMethod()]
        public void ResetDailyProductsSoldTests()
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);



            
        }

        [TestMethod()]
        public void DiscountDay_IsDicountDayTest()
        {


        }

        [TestMethod()]
        public void NotDiscountDay_IsDicountDayTest()
        {


        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void SellProductTest(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.GetProduct(productName);
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("ReceiveProduct", productName);
            IProduct product = shop.Products[0];

            shop.SellProduct(productName);

            int counter = shop.DailyProductsSold[productName];
            Assert.AreEqual(1, counter);

            Assert.AreEqual(product.Price, shop.DailyEarnings);
            Assert.AreEqual(0, shop.Products.Count);
        }

        [TestMethod()]
        public void ServeCustomerTest()
        {

        }

        [TestMethod()]
        public void SendDailyEarningsTests()
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider)
            {
                DailyEarnings = 100
            };
            decimal revenueInit = company.Revenue;
            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("SendDailyEarnings");

            Assert.AreEqual(revenueInit + 100, company.Revenue);
            Assert.AreEqual(0, shop.DailyEarnings);
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void NotLowQuantity_IsProductQuantityLowTests(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.GetDailyProducts();
            Shop shop = new Shop(company, factory, customerProvider);

            int stockProducts = 0;
            switch (productName)
            {
                case "BlackChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }
            PrivateObject privateObject = new PrivateObject(shop);

            for (int i = 0; i < stockProducts; i++)
            {
                privateObject.Invoke("ReceiveProduct", productName);
            }

            Assert.IsFalse((bool)privateObject.Invoke("IsProductQuantityLow", productName), "The product quantity was low.");
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void LowQuantity_IsProductQuantityLowTests(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.GetDailyProducts();
            Shop shop = new Shop(company, factory, customerProvider);

            int stockProducts = 0;
            switch (productName)
            {
                case "BlackChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }
            PrivateObject privateObject = new PrivateObject(shop);

            for (int i = 0; i < stockProducts - 1; i++)
            {
                privateObject.Invoke("ReceiveProduct", productName);
            }

            Assert.IsTrue((bool)privateObject.Invoke("IsProductQuantityLow", productName), "The product quantity was not low.");
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RefillProductTests(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.GetDailyProducts();
            Shop shop = new Shop(company, factory, customerProvider);

            int productMaxCapacity = 0;

            switch (productName)
            {
                case "BlackChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }

            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("RefillProduct", productName);

            Assert.AreEqual(productMaxCapacity, shop.Products.Where(x => x.Description == productName).Count());
        }

        [TestMethod()]
        public void RefillStockTest()
        {

        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void ReceiveProductTest(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.GetProduct(productName);
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("ReceiveProduct", productName);

            Assert.AreEqual(1, shop.Products.Count);
            Assert.AreEqual(productName, shop.Products[0].Description);
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
            factory.Warehouse.GetProduct(productName);
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("ReceiveProduct", productName);
            privateObject.Invoke("RemoveExpiredProducts", yesterday);

            Assert.AreEqual(productName, shop.Products[0].Description);
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RemoveExpiredProducts(string productName)
        {
            DateTime today = DateTime.Today;
            DateTime farFuture = today.AddDays(10000);

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.GetProduct(productName);
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("ReceiveProduct", productName);
            privateObject.Invoke("RemoveExpiredProducts", farFuture);

            int counter = shop.DailyProductsSold[productName];

            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, shop.Products.Count);
        }







    }
}

