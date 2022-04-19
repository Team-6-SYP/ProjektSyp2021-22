using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("Employees", Schema = "timemanagement")]
    public class Employee : Person
    {
        [Required]
        public DateOnly HireDate { get; set; }

        [Required]
        public double WeeklyHours { get; set; }

        [Required]
        public int WorkingDaysPerWeek { get; set; }

        [NotMapped]
        public double DailyWorkingTime => WeeklyHours / WorkingDaysPerWeek; // div durch 0

        [Required]
        public Weekday BeginWorkingWeek { get; set; }

        public double? TransferVacationDays { get; set; }

        [NotMapped]
        public double CurrentVacateionDays; //wird berechnet


        //navigagion Properties
        public IEnumerable<Rate> Rates { get; set; } = new List<Rate>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();
    }
}
