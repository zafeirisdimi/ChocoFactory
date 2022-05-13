using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Services;

namespace ChocoFactory.Domain
{
    
    class Production: Department
    {
        public Factory Factory { get; set; }
        public ProductionPolicy ProductionPolicy { get; set; }


        public Product CreateProduct(string productName)
        {
            Product createdProduct = null;

            switch (productName)
            {
                case "BlackChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.BlackChocolateSupplies);
                    createdProduct = new BlackChocolate();
                    createdProduct.Description = "BlackChocolate";
                    createdProduct.ProductionDate = DateTime.Now;
                    createdProduct.ExpirationDate = DateTime.Now.AddDays(90);
                    createdProduct.Price = Factory.Company.CompanyPolicy.BlackChocolatePrice;
                    break;
                case "WhiteChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.WhiteChocolateSupplies);
                    createdProduct = new WhiteChocolate();
                    createdProduct.Description = "WhiteChocolate";
                    createdProduct.ProductionDate = DateTime.Now;
                    createdProduct.ExpirationDate = DateTime.Now.AddDays(60);
                    createdProduct.Price = Factory.Company.CompanyPolicy.WhiteChocolatePrice;
                    break;
                case "PlainMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.MilkChocolateSupplies);
                    createdProduct = new PlainMilkChocolate();
                    createdProduct.Description = "PlainMilkChocolate";
                    createdProduct.ProductionDate = DateTime.Now;
                    createdProduct.ExpirationDate = DateTime.Now.AddDays(75);
                    createdProduct.Price = Factory.Company.CompanyPolicy.MilkChocolatePrice;
                    break;
                case "AlmondMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.AlmondMilkChocolateSupplies);
                    createdProduct = new AlmondMilkChocolate();
                    createdProduct.Description = "AlmondMilkChocolate";
                    createdProduct.ProductionDate = DateTime.Now;
                    createdProduct.ExpirationDate = DateTime.Now.AddDays(75);
                    createdProduct.Price = Factory.Company.CompanyPolicy.AlmondMilkChocolatePrice;
                    break;
                case "HazelnutMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.HazelnutMilkChocolateSupplies);
                    createdProduct = new HazelnutMilkChocolate();
                    createdProduct.Description = "HazelnutMilkChocolate";
                    createdProduct.ProductionDate = DateTime.Now;
                    createdProduct.ExpirationDate = DateTime.Now.AddDays(75);
                    createdProduct.Price = Factory.Company.CompanyPolicy.HazelnutMilkChocolatePrice;
                    break;
                case "ExperimentalProduct":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.ExperimentalChocolateSupplies);
                    createdProduct = new ExperimentalProduct();
                    createdProduct.Description = "ExperimentalProduct";
                    createdProduct.ProductionDate = DateTime.Now;
                    createdProduct.ExpirationDate = DateTime.Now.AddDays(300);
                    createdProduct.Price = 0;
                    break;
                default:
                    Console.WriteLine("Error creating product");
                    break;
                   
               
            }
            return createdProduct;
            
        }

     



    }
}
