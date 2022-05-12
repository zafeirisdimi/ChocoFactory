﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    internal class CompanyPolicy
    {
        public int DailyProducts { get; set; } = 500;
        public double ProductsToShopPercent { get; set; } = 0.50;
        public double ShopRestockPercent { get; set; } = 0.25;
        public double ShopDiscount { get; set; } = 0.20;
        public decimal GiftMinimumPrice { get; set; } = 30;
        public double MinimumRevenueToInvest { get; set; } = 0.25;


    }
}