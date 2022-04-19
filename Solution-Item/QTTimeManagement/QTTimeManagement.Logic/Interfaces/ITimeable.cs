using QTTimeManagement.Logic.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Interfaces
{
    public interface ITimeable
    {
        public TimeType TimeType { get; set; }
        public TimeOnly Begin { get; set; }
        public TimeOnly End { get; set; }
        public TimeSpan Duration => End - Begin;
        public int Position { get; set; }
    }
}
