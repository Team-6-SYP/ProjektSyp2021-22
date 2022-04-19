using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    public class Holiday : VersionEntity
    {
        public static IEnumerable<Holiday> Holidays { get; set; } = new List<Holiday>();

        public string Name { get; set; }
        public DateOnly Date { get; set; }
    }
}
