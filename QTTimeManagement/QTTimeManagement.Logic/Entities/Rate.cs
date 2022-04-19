using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class Rate : ValidityEntity, IRateable
    {
        public RateType RateType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal RateAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
