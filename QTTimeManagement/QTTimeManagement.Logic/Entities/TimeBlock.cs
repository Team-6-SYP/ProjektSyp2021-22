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

        public TimeSpan? Begin { get; set; } //TimeOnly

        [Required]
        public TimeSpan End { get; set; } //TimeOnly

        [Required]
        public bool OnCompanyTerrain { get; set; } //for diet clculation

        [MaxLength(2000)]
        public string? Notice { get; set; }

        //navigation properties
        public Service? Service { get; set; }
        public ServiceTemplate? ServiceTemplate { get; set; }

        
    }
}
