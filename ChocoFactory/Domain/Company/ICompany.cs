using System;

namespace ChocoFactory.Domain
{
    public interface ICompany
    {
        decimal Capital { get; }
        decimal Revenue { get; set; }

        void DailyActions(DateTime currentDate);
        void YearlyActions();

        
    }
}