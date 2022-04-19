using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class ValidityEntity : VersionEntity, IValidityable
    {
        public DateOnly Begin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateOnly? End { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
