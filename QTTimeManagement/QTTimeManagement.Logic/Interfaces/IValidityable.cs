using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Interfaces
{
    public interface IValidityable<T>
    {
        public DateTime Begin { get; set; } //darf nur mit Zeit 00:00 eingetragen werden
        public DateTime? End { get; }
        public Predicate<T> VadilityPredicate { get; init; }
    }
}
