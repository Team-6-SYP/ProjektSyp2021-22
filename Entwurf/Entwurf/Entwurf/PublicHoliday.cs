using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public class PublicHoliday : Rowversion
    {
        public string Name { get; set; }

        public DateOnly HolidayDate { get; set; }
    }
}