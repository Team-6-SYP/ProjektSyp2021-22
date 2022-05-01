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
    public class ServiceTemplate : ValidityEntity<ServiceTemplate>
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
        public IEnumerable<TimeBlock> TimeBlocks { get; set; } = new List<TimeBlock>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();

        [NotMapped]
        public override Predicate<ServiceTemplate> VadilityPredicate { get; init; }

        public ServiceTemplate()
        {
            VadilityPredicate = (st) => st.Name == Name;
        }
    }
}
