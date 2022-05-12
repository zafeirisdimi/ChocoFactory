using System;
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
        public DayOfWeek DiscountDay { get; set; } = DayOfWeek.Tuesday;
        public int DiscountDayOccurence { get; set; } = 2; // Every second Tuesday of each month.
        public decimal GiftMinimumPrice { get; set; } = 30;
        public double MinimumRevenueToInvest { get; set; } = 0.25;
        public double RevenueYearlyGoal { get; set; } = 0.15;
        public double BlackChocolatePercent { get; set; } = 0.5;
        public double WhiteChocolatePercent { get; set; } = 0.2;
        public double MilkChocolatePercent { get; set; } = 0.1;
        public double AlmondMilkChocolate { get; set; } = 0.1;
        public double HazelnutMilkChocolate { get; set; } = 0.1;
        



    }
}
