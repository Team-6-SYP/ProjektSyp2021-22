using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class TimesheetDay : ServiceTemplate
    {
        public int EmployeeId { get; set; }

        public int GlobalTimesheetPropertyId { get; set; }

        public DateOnly Day { get; set; }

        public bool IsPublicHoliday;



        //nav.
        public Employee Employee { get; set; }

        public GlobalTimesheetProperty GlobalTimesheetProperty { get; set; }
    }
}