using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Index(nameof(Begin))]
    public abstract class ValidityEntity<T> : VersionEntity, IValidityable<T>
    {
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Begin { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? End { get; internal set; }

        [NotMapped]
        public DateOnly BeginDateOnly => DateOnly.FromDateTime(Begin);

        [NotMapped]
        public DateOnly? EndDateOnly => End != null ? DateOnly.FromDateTime(End.Value) : null;

        [NotMapped]
        public abstract Predicate<T> VadilityPredicate { get; init; }
    }
}
