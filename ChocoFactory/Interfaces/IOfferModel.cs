using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Interfaces
{
    interface IOfferModel 
    {
         int OfferID { get; }
         int OfferedPrice { get; }
    }
}
