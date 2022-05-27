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
        [Column(TypeName = "Date")]
        public DateTime? HireDate { get; set; }

        [Required]
        public double WeeklyHours { get; set; }

        [Required]
        public int WorkingDaysPerWeek { get; set; }

        [NotMapped]
        public double DailyWorkingTime
        {
            get
            {
                if (WorkingDaysPerWeek == 0)
                    throw new InvalidOperationException("Division durch null !");

                return WeeklyHours / WorkingDaysPerWeek;
            }
        }

        [Required]
        public Weekday BeginWorkingWeek { get; set; }

        [Required]
        public double VacationDaysPerYear { get; set; }

        public double? TransferVacationDays { get; set; }

        [NotMapped]
        public double CurrentVacationDays => VacationDaysPerYear + (TransferVacationDays ?? 0); //Randbemerkung:  Urlaubsanspruch / Tag (bei 5 T) =  0,0684462696783

        [NotMapped]
        public IEnumerable<Service> VacationDays => Services.Where(s => s.ServiceType == ServiceType.Vacation);

        [NotMapped]
        public IEnumerable<Service> SickLeaveDays => Services.Where(s => s.ServiceType == ServiceType.Sickleave) ;
              
        [NotMapped]
        public IEnumerable<Service> SpecialCaseDays => Services.Where(s => s.ServiceType == ServiceType.SpecialCase);

        [NotMapped]
        public IEnumerable<Service> WorkingDays => Services.Where(s => s.ServiceType == ServiceType.Working);


        //navigagion Properties
        public IEnumerable<Rate> Rates { get; set; } = new List<Rate>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();

        public override string ToString()
        {
            return $"Emp: {Id} - {FirstName} - {LastName}";
        }
    }
}
