using QTTimeManagement.Logic.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public abstract class Person : VersionEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DayOfBirth { get; set; }
    }
}
