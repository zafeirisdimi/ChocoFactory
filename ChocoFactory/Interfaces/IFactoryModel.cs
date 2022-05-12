using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Interfaces
{
    interface IFactoryModel
    {
        int ID { get; }

        string City { get; set; }
        string Address { get; set; }

        double TotalProducts { get; }
        double TotalEmployees { get; }

    }
}
