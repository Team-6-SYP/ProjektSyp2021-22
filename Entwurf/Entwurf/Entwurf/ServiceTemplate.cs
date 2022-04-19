using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public abstract class ServiceTemplate : Rowversion
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public TimeOnly OperatingTimeBegin { get; set; }

        public TimeOnly OperatingTimeEnd { get; set; }

        public TimeSpan ServicePeriode => OperatingTimeEnd - OperatingTimeBegin;



        //nav.
        public IEnumerable<Break> Breaks { get; set; }

        public IEnumerable<PreperationTime> PreperationTimes { get; set; }
    }
}