using QTTimeManagement.Logic.Enumerations;

namespace QTTimeManagement.WebApi.Models
{
    public class RateEdit
    {

        public RateType RateType { get; set; }


        public double RateAmount { get; set; }

        public int EmployeeId { get; set; }

       

    }
}
