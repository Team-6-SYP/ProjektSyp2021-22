using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTTimeManagement.Logic.Controllers;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<Logic.Entities.Employee, Models.EmployeeEdit, Models.Employee>
    {
        public EmployeesController(GenericController<Employee> controller) : base(controller)
        {
        }
    }
}
