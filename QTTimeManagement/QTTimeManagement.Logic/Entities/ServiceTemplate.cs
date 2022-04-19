using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("ServiceTemplates", Schema = "timemanagement")]
    [Index(nameof(Name), nameof(Begin), IsUnique = true)]
    public class ServiceTemplate : ValidityEntity
    {
        [Required]
        public Weekday Validitydays { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Notes { get; set; }


        //navigation properties
        [NotMapped]
        public IEnumerable<ITimeable> ServiceBlocks { get; set; } = new List<ITimeable>();

    }
}
