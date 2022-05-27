using QTTimeManagement.Logic.Enumerations;

namespace QTTimeManagement.WebApi.Models
{
    public class Rate : IdentityModel
    {
                
        public RateType RateType { get; set; }

       
        public double RateAmount { get; set; }

        public int EmployeeId { get; set; }

       
        

    }
}
