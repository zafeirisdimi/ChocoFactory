using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    internal class Factory
    {
        //properties
        public Company Company { get; set; }
        public Warehouse Warehouse { get; set; } = new Warehouse();
        public Production Production { get; set; } = new Production();
        public Accounting Accounting { get; set; } = new Accounting();
        public List<Shop> Shops { get; set; } = new List<Shop>();
    }
}
