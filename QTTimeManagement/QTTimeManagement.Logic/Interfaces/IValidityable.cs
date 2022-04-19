using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Interfaces
{
    public interface IValidityable
    {
        public DateOnly Begin { get; set; }
        public DateOnly? End { get; set; }
    }
}
