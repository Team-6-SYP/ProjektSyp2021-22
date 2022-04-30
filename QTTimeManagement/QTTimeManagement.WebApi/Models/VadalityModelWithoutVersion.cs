namespace QTTimeManagement.WebApi.Models
{
    public class VadalityModelWithoutVersion : IdentityModel
    {
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
    }
}
