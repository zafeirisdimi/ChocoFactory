using System;
using System.Collections.Generic;

namespace ChocoFactory.Domain
{
     interface IFactory
    {
        Accounting Accounting { get; set; }
        Production Production { get; set; }
        Warehouse Warehouse { get; set; }

        void DailyActions(DateTime currentDate);
        void YearlyActions();
    }
}