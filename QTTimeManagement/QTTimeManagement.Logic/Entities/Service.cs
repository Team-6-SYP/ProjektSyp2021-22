using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("Services", Schema = "timemanagement")]
    public class Service
    {
        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        [Required]
        public DateTime ServiceDay { get; set; }   

        public bool IsNotCompliant { get; set; }
        public string? NotCompliantNotice { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public int? ServiceTemplateId { get; set; }


        //navigation Properties
        public Employee? Employee { get; set; }
        public ServiceTemplate? ServiceTemplate { get; set; }

        [NotMapped]
        public IEnumerable<ITimeable> ServiceBlocks { get; set; } = new List<ITimeable>();

        //Kommentar
    }
}
