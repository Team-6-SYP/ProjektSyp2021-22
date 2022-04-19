using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class Service
    {
        public string Name { get; set; }
        public string? Notes { get; set; }
        public DateOnly ServiceDay { get; set; }

        public Employee Employee { get; set; }

        public int? ServiceTemplateId { get; set; }

        public IEnumerable<ITimeable> ServiceBlocks { get; set; } = new List<ITimeable>();

        public bool IsNotCompliant { get; set; }
        public string? NotCompliantNotice { get; set; }
    }
}
