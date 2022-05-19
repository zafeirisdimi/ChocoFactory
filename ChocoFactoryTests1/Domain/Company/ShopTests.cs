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
            Company company = new Company();
            Factory factory = new Factory(company);
            Shop shop = new Shop(company, factory);

            PrivateObject privateObject = new PrivateObject(shop);



            
        }

        [TestMethod()]
        public void IsDicountDayTest()
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
            Company company = new Company();
            Factory factory = new Factory(company);
            Shop shop = new Shop(company, factory);


        }

        [TestMethod()]
        public void ServeCustomerTest()
        {

        }

        [TestMethod()]
        public void SendDailyEarningsTests()
        {

        }

        [TestMethod()]
        public void IsProductQuantityLowTests()
        {

        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RefillProductTests(string productName)
        {
            Company company = new Company();
            Factory factory = new Factory(company);
            factory.Warehouse.GetProduct(productName);
            Shop shop = new Shop(company, factory);

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

            

            //Assert.AreEqual(productMaxCapacity, );
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
            Company company = new Company();
            Factory factory = new Factory(company);
            factory.Warehouse.GetProduct(productName);
            Shop shop = new Shop(company, factory);


            PrivateObject privateObject = new PrivateObject(shop);

            privateObject.Invoke("ReceiveProduct", productName);

            Assert.AreEqual(1, shop.Products.Count);
            Assert.AreEqual(productName, shop.Products[0].Description);
        }

        [TestMethod()]
        public void RemoveExpiredProducts()
        {

        }





    }
}

