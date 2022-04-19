using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entwurf
{
    public abstract class Rate : Rowversion
    {
        public int EmployeeId { get; set; }

        public DateOnly ValityDate { get; set; }

        public DateOnly ValityDateEnd;

        public decimal HourlyRate { get; set; }
    }
}
