﻿using ChocoFactory.Interfaces;
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
        public ProductionPolicy ProductionPolicy { get; set; } = new ProductionPolicy();


        public Production(Factory factory)
        {
            Factory = factory;
        }


        public Product CreateProduct(string productName)
        {
            Product createdProduct = null;

            switch (productName)
            {
                case "BlackChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.BlackChocolateSupplies);
                    createdProduct = new BlackChocolate()
                    {
                        Description = "BlackChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(90),
                        Price = Factory.Company.CompanyPolicy.BlackChocolatePrice
                    };
                    break;
                case "WhiteChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.WhiteChocolateSupplies);
                    createdProduct = new WhiteChocolate()
                    {
                        Description = "WhiteChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(60),
                        Price = Factory.Company.CompanyPolicy.WhiteChocolatePrice
                    };
                    break;
                case "PlainMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.MilkChocolateSupplies);
                    createdProduct = new PlainMilkChocolate()
                    {
                        Description = "PlainMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = Factory.Company.CompanyPolicy.MilkChocolatePrice
                    };
                    break;
                case "AlmondMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.AlmondMilkChocolateSupplies);
                    createdProduct = new AlmondMilkChocolate()
                    {
                        Description = "AlmondMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = Factory.Company.CompanyPolicy.AlmondMilkChocolatePrice
                    };
                    break;
                case "HazelnutMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.HazelnutMilkChocolateSupplies);
                    createdProduct = new HazelnutMilkChocolate()
                    {
                        Description = "HazelnutMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = Factory.Company.CompanyPolicy.HazelnutMilkChocolatePrice
                    };
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
