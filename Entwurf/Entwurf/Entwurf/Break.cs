using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class Break : Rowversion
    {
        public int ServiceTemplateId { get; set; }

        public TimeOnly BreakBegin { get; set; }

        public TimeOnly BreakEnd { get; set; }

        public TimeSpan BreakDuration => BreakEnd - BreakBegin;

        //nav.
        public ServiceTemplate Service { get; set; }

    }
}