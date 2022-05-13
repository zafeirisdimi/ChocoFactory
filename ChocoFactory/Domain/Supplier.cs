using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    class Supplier
    {
        //properties
        public int ID { get; set; }// SupplierID

        //methods
        public void SendSupplies(Order order)
        {
            Warehouse warehouseToSend = order.Factory.Warehouse;
            warehouseToSend.SuppliesInKilo += order.Quantity;
        }

        public Offer SendOffer(decimal pricePerKilo, Quality quality, int suppliesKilos)
        {
            return new Offer(pricePerKilo, quality, suppliesKilos, this);
        }
        
    }
}
