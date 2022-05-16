using ChocoFactory.Services;
using System;
using System.Collections.Generic;

namespace ChocoFactory.Domain
{
     interface ICompany
    {
        decimal Capital { get; }
        CompanyPolicy CompanyPolicy { get; set; }
        List<Employee> Employees { get; set; }
        
        decimal Revenue { get; set; }
        bool RevenueGoalAchieved { get; }
        

        void DailyActions(DateTime currentDate);
        void Initialization();
        void YearlyActions();
    }
}