using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class HourlyWageRate : Rate
    {
        public int EmployeeId { get; set; }

        //nav.
        public Employee Employee { get; set; }
    }
}