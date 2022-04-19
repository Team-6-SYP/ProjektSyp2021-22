using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("Holidays", Schema = "timemanagement")]
    public class Holiday : VersionEntity
    {
        [NotMapped]
        public static IEnumerable<Holiday> Holidays { get; set; } = new List<Holiday>();

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }
    }
}
