using QTTimeManagement.Logic.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Interfaces
{
    public interface IRateable
    {
        public RateType RateType { get; set; }
        public double RateAmount { get; set; }
    }
}
