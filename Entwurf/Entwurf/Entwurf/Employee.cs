using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class Employee : Person
    {
        public DateOnly HireDate { get; set; }

        public double WeeklyHours { get; set; }

        public int WorkingDaysPerWeek { get; set; }

        public double DailyWorkingTime => WeeklyHours / WorkingDaysPerWeek; // div durch 0

        public Weekday BeginWorkingWeek { get; set; }

        public double TransferVacationDays { get; set; }

        public double CurrentVacateionDays; //wird berechnet


        //nav.
        public IEnumerable<HourlyWageRate> HourlyWageRates { get; set; }

        public IEnumerable<VactaionAndSickleaveRate> VacationAndSickleaveRates { get; set; }

        public IEnumerable<MounthlyVacationDay> MonthlyVacationDays { get; set; }

        public IEnumerable<TimesheetDay> WorkingDays { get; set; }

    }
}