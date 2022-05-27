using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTTimeManagement.Logic.Controllers;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : GenericController<Logic.Entities.Rate, Models.RateEdit, Models.Rate>
    {
        public RatesController(GenericController<Rate> controller) : base(controller)
        {
        }
    }
}
