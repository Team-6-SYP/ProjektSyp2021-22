using QTTimeManagement.Logic.Enumerations;

namespace QTTimeManagement.WebApi.Models
{
    public class EmployeeEdit
    {
        public DateTime? HireDate { get; set; }

        public double WeeklyHours { get; set; }

        public int WorkingDaysPerWeek { get; set; }

        public double DailyWorkingTime
        {
            get
            {
                if (WorkingDaysPerWeek == 0)
                    throw new InvalidOperationException("Division durch null !");

                return WeeklyHours / WorkingDaysPerWeek;
            }
        }

        public Weekday BeginWorkingWeek { get; set; }


        public double VacationDaysPerYear { get; set; }

        public double? TransferVacationDays { get; set; }

    }
}
