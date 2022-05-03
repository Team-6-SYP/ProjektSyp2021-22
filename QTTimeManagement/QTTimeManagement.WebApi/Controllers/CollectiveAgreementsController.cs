using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTTimeManagement.Logic.Controllers;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectiveAgreementsController : GenericController<Logic.Entities.CollectiveAgreement, Models.CollectiveAgreementEdit, Models.CollectiveAgreement>
    {
        public CollectiveAgreementsController(Logic.Controllers.CollectiveAgreementsController controller) : base(controller)
        {
        }
    }
}
