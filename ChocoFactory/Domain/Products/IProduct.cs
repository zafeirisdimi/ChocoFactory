using System;

namespace ChocoFactory.Interfaces
{
    public interface IProduct
    {
        //properties
        int ID { get; }
        string Description { get; }
        DateTime ProductionDate { get; }
        decimal Price { get; }

        //methods
    }
}