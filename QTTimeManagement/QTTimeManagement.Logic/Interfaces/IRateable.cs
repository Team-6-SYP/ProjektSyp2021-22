using QTTimeManagement.Logic.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Interfaces
{
    public interface IRateable : IValidityable
    {
        public RateType RateType { get; set; }
        public decimal RateAmount { get; set; }
    }
}
