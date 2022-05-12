using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    public class CompanyPolicy
    {
        // Factory
        public int DailyProducts { get; set; } = 500;
        public double LowSuppliesThresholdPercent { get; set; } = 0.10;
        public double MinimumRevenueToInvest { get; set; } = 0.25;
        public double RevenueYearlyGoal { get; set; } = 0.15;

        // Production Percent
        public double BlackChocolatePercent { get; set; } = 0.50;
        public double WhiteChocolatePercent { get; set; } = 0.20;
        public double MilkChocolatePercent { get; set; } = 0.10;
        public double AlmondMilkChocolatePercent { get; set; } = 0.10;
        public double HazelnutMilkChocolatePercent { get; set; } = 0.10;

        // Shop
        public double ProductsToShopPercent { get; set; } = 0.50;
        public double ShopRestockPercent { get; set; } = 0.25;
        public int ShopStockSize
        {
            get { return (int)Math.Floor(DailyProducts * ProductsToShopPercent); }
        }
        public int ShopRestockThreshold
        {
            get { return (int)Math.Floor(DailyProducts * ProductsToShopPercent * ShopRestockPercent)}
        }
        public double ShopDiscount { get; set; } = 0.20;
        public DayOfWeek DiscountDay { get; set; } = DayOfWeek.Tuesday;
        public int DiscountDayOccurence { get; set; } = 2; // Every second Tuesday of each month.
        public decimal GiftMinimumPrice { get; set; } = 30;


        // Prices
        public decimal BlackChocolatePrice { get; set; } = 5;
        public decimal WhiteChocolatePrice { get; set; } = 6;
        public decimal MilkChocolatePrice { get; set; } = 5;
        public decimal AlmondMilkChocolatePrice { get; set; } = 8;
        public decimal HazelnutMilkChocolatePrice { get; set; } = 8;





    }
}
