﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    internal class Factory
    {
        //properties
        public Warehouse Warehouse { get; set; }
        public Production Production { get; set; }
        public Company Company { get; set; }

        public Accounting Accounting { get; set; }

        
        //methods

    }
}