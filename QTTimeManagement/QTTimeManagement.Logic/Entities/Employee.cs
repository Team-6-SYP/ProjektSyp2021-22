using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
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


        public IEnumerable<Rate> Rates { get; set; } = new List<Rate>();
    }
}
