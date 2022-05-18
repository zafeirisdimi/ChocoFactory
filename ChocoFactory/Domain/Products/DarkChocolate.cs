using ChocoFactory.Interfaces;
using System;

namespace ChocoFactory.Domain
{
    public class BlackChocolate : IChocolateModel, IProductModel
    {
        public DateTime ExpirationDate { get; }

        public string Description { get; }
        public DateTime ProductionDate { get; }
        public decimal Price { get; }

        int IProductModel.ID { get; }
    }
}