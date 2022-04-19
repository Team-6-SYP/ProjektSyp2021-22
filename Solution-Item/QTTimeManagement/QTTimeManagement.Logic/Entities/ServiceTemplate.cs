using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class ServiceTemplate : ValidityEntity
    {
        public Weekday Validitydays { get; set; }

        public string Name { get; set; }
        public string? Notes { get; set; }

        public IEnumerable<ITimeable> ServiceBlocks { get; set; } = new List<ITimeable>();

    }
}
