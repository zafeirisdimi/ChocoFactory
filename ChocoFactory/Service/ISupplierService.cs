using ChocoFactory.Domain;
using System.Collections.Generic;

namespace ChocoFactory.Services
{
    internal interface ISupplierService
    {
        List<Offer> Offers(Factory factory);
    }
}