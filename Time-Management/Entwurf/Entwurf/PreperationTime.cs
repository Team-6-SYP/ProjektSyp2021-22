using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class PreperationTime : Rowversion
    {
        public int ServiceTemplateId { get; set; }

        public TimeOnly PreperationBegin { get; set; }

        public TimeOnly PreperationEnd { get; set; }

        public TimeSpan PreperationDuration => PreperationEnd - PreperationBegin;

        //nav.
        public ServiceTemplate Service { get; set; }
    }
}