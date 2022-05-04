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
        public double VacationWeeksPerYear { get; set; }

        public double? TransferVacationDays { get; set; }

        [NotMapped]
        public double CurrentVacationDays
        {
            get
            {
                if (HireDate != null)
                {
                    if (DateTime.Now.Year == HireDate.Value.Year)
                    {
                        var result = DateTime.Now - HireDate;

                        return (result.Value.Days * 0.0686813);
                    }
                    else if ((DateTime.Now.Year - HireDate.Value.Year) >= 25)
                    {
                        return 30.0; // bei 25 Jahren Dienstzeit = 30 Tage Anspruch
                    }
                    else
                        return 25.0; // bei einer 5 Tageswoche = 25 Tage Anspruch


                    //  6 Tage - Woche = 30 Arbeits / Urlaubstage

                    // 5 Tage - Woche = 25 Arbeits / Urlaubstage

                    //4 Tage - Woche = 20 Arbeits / Urlaubstage

                    //3 Tage - Woche = 15 Arbeits / Urlaubstage

                    //2 Tage - Woche = 10 Arbeits / Urlaubstage

                    //1 Tag - Woche = 5 Arbeits / Urlaubstage 
                }

                return 0;

            }
        }

        //navigagion Properties
        public IEnumerable<Rate> Rates { get; set; } = new List<Rate>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();
    }
}
