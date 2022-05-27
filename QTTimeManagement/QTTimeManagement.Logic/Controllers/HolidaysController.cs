using QTTimeManagement.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Controllers
{
    public sealed class HolidaysController : GenericController<Holiday>
    {
        public HolidaysController()
        {
        }

        public HolidaysController(ControllerObject other) : base(other)
        {
        }
    }
}
