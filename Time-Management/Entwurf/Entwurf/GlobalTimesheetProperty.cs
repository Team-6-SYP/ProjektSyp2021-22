using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class GlobalTimesheetProperty : Rowversion
    {
        public DateOnly ValityDate { get; set; }

        public DateOnly ValityDateEnd;

        public TimeOnly NightHoursBegin { get; set; }

        public TimeOnly NightHoursEnd { get; set; }

        public TimeSpan MaximumBreakDuration { get; set; }

        public decimal Diet { get; set; } //Diät


        //nav.
        public IEnumerable<TimesheetDay> TimesheetDays { get; set; }



    }
}