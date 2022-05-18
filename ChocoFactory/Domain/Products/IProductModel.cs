using System;

namespace ChocoFactory.Interfaces
{
    public interface IProductModel
    {
        //properties
        int ID { get; }

        string Description { get; }
        DateTime ProductionDate { get; }
        decimal Price { get; }

        //methods
    }
}