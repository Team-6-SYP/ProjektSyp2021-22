using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("Rates", Schema = "timemanagement")]
    [Index(nameof(Begin), nameof(RateType), nameof(EmployeeId), IsUnique = true)]
    public class Rate : ValidityEntity<Rate>, IRateable
    {
        [Required]
        public RateType RateType { get; set; }

        [Required]
        public double RateAmount { get; set; }

        public int EmployeeId { get; set; } 

        //navigation properties
        public Employee? Employee { get; set; }

        [NotMapped]
        public override Predicate<Rate> VadilityPredicate { get; init; }

        public Rate()
        {
            VadilityPredicate = (r) => r.RateType == RateType && r.EmployeeId == r.EmployeeId;
        }
    }
}
