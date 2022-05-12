using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Interfaces
{
    interface IOrderModel
    {
        int OrderID { get; }

        double Price { get; }

        string GatewayPayment { get; }
       
    }
}
