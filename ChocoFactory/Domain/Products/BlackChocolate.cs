using ChocoFactory.Interfaces;
using System;

namespace ChocoFactory.Domain
{
    public class BlackChocolate : IChocolate, IProduct
    {
        public DateTime ExpirationDate { get; set; }

        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }

        int IProduct.ID { get; }
    }
}