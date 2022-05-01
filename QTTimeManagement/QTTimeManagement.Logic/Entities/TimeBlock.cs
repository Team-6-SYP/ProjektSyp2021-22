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

        public DateTime? Begin { get; set; } //TimeOnly

        [Required]
        public DateTime End { get; set; } //TimeOnly

        [Required]
        public bool OnCompanyTerrain { get; set; } //for diet clculation

        [MaxLength(2000)]
        public string? Notice { get; set; }

        //calculated properties
        [NotMapped]
        public TimeOnly BeginTimeOnly => Begin == null ? new TimeOnly() : TimeOnly.FromDateTime(Begin.Value);

        [NotMapped]
        public TimeOnly EndTimeOnly => TimeOnly.FromDateTime(End);

        //navigation properties
        public Service? Service { get; set; }
        public ServiceTemplate? ServiceTemplate { get; set; }

    }
}
