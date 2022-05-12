﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Interfaces
{
    interface IProductModel
    {
        int ID { get; }
        string Description { get; }
        DateTime dateTime { get; }
    }
}
