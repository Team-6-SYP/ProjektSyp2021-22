using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("TimeBlocks", Schema = "timemanagement")]
    public class TimeBlock : VersionEntity, ITimeable
    {
        public int? ServiceId { get; set; } // one of both needs to be set
        public int? ServiceTemplateId { get; set; } // one of both needs to be set

        [Required]
        public TimeType TimeType { get; set; }

        [Required]
        public DateTime Begin { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int Index { get; set; }


        //navigation Properties
        public Service? Service { get; set; }
        public ServiceTemplate? ServiceTemplate { get; set; }

    }
}
