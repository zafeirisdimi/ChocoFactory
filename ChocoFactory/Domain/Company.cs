using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    internal class Company
    {
        public decimal Capital { get; set; } = 1000000;
        public decimal Revenue { get; set; }
        public List<Factory> Factories { get; set; } = new List<Factory>();
        public List<Shop> Shops { get; set; } = new List<Shop>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public CompanyPolicy CompanyPolicy { get; set; }


        public bool RevenueGoalAchieved()
        {
            return Revenue > (decimal)CompanyPolicy.RevenueYearlyGoal * Revenue;
        }

    }
}
