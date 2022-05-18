using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain.Products
{
    public class WhiteChocolate : IChocolate, IProduct
    {
        public int ID { get; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }

    }
}
