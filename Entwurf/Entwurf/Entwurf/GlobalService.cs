using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class GlobalService : ServiceTemplate
    {
        public DateOnly ValityDate { get; set; }

        public Weekday ValityDays;

        public DateOnly ValityDateEnd; //muss berechnet werden.

    }
}