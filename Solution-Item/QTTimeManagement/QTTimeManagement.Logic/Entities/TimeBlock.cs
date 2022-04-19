using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class TimeBlock : VersionEntity, ITimeable
    {
        public TimeType TimeType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeOnly Begin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeOnly End { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
