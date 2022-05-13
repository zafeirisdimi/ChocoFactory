using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    internal class ProductionPolicy
    {
        public int BlackChocolateSupplies { get; set; } = 1;
        public int WhiteChocolateSupplies { get; set; } = 1;
        public int MilkChocolateSupplies { get; set; } = 1;
        public int AlmondMilkChocolateSupplies { get; set; } = 1;
        public int HazelnutMilkChocolateSupplies { get; set; } = 1;
        public int ExperimentalChocolateSupplies { get; set; } = 1;
    }
}
