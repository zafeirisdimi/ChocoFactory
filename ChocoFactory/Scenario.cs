﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Domain;
using ChocoFactory.Services;

namespace ChocoFactory
{

    public class Scenario : IScenario

    {
        private readonly ICompany _comapny;
       

        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; } = new DateTime(2023, 1, 30);

        private DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime CurrentDate
        {
            get { return currentDate; }
        }
        public Calendar Calendar { get; } = CultureInfo.InvariantCulture.Calendar;

        public Scenario(ICompany company)
        {
            _comapny = company;
        }
        public void Start()
        {
            
            AdvanceTime();

            Console.WriteLine("End of Scenario");

            Console.WriteLine($"Final Company Capital: {_comapny.Capital}");
            Console.WriteLine($"Final Company Revenue: {_comapny.Revenue}");
        }

        public void AdvanceTime()
        {
            while (CurrentDate != EndingDate)
            {
                if (CurrentDate.Day == 1 && CurrentDate.Month == 1) // Do this on the first day of the year.
                    _comapny.YearlyActions();

                _comapny.DailyActions(CurrentDate); // Do this everyday.

                currentDate = Calendar.AddDays(CurrentDate, 1); // Advance Time by one day.

                Console.WriteLine($"End of day {currentDate}\n");
            }
        }



    }
}
