using System;

namespace ChocoFactory.Domain
{
    internal interface ICompany
    {
        decimal Capital { get; }
        decimal Revenue { get; set; }

        void DailyActions(DateTime currentDate);
        void YearlyActions();

        void Initialization();
    }
}