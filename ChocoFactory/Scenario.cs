using System;
using System.Globalization;

namespace ChocoFactory
{
    public class Scenario
    {
        private Company company = new Company(); // create Company object

        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; } = new DateTime(2023, 1, 30);

        private DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public DateTime CurrentDate
        {
            get { return currentDate; }
        }

        public Calendar Calendar { get; } = CultureInfo.InvariantCulture.Calendar;

        public void Start()
        {
            company.Initialization();
            AdvanceTime();

            Console.WriteLine("End of Scenario");

            Console.WriteLine($"Final Company Capital: {company.Capital}");
            Console.WriteLine($"Final Company Revenue: {company.Revenue}");
        }

        public void AdvanceTime()
        {
            while (CurrentDate != EndingDate)
            {
                if (CurrentDate.Day == 1 && CurrentDate.Month == 1) // Do this on the first day of the year.
                    company.YearlyActions();

                company.DailyActions(CurrentDate); // Do this everyday.

                currentDate = Calendar.AddDays(CurrentDate, 1); // Advance Time by one day.

                Console.WriteLine($"End of day {currentDate}\n");
            }
        }
    }
}