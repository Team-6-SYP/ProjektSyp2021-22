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
    public class Rate : ValidityEntity, IRateable
    {
        private decimal rateAmount;

        [Required]
        public RateType RateType { get; set; }

        [Required]
        public decimal RateAmount
        {
            get => rateAmount; set
            {
                if (value < 0)
                    throw new Logic.Modules.Exceptions.LogicException("Rate has to be a positiv value");

                rateAmount = value;
            }
        }
    }
}
