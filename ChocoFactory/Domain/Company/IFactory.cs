﻿using ChocoFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Company
{
    interface IFactory : IDeparmentModel
    {
        int ID { get; }
        string City { get; }
        string Address { get; }
        double TotalProducts { get; }
        double TotalEmployees { get; }

    }
}
