using ChocoFactory.Services;
using System;
using System.Collections.Generic;

namespace ChocoFactory.Domain
{
    public interface ICompany
    {
        decimal Capital { get; }
        decimal Revenue { get; set; }
        List<Factory> Factories { get; set; }
        List<Shop> Shops { get; set; }
        List<IEmployeeModel> Employees { get; set; }
        CompanyPolicy CompanyPolicy { get; set; }
        bool RevenueGoalAchieved { get; set; }
        void DailyActions(DateTime currentDate);
        void YearlyActions();


    }
}