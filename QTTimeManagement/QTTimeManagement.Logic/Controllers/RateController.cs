using QTTimeManagement.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Controllers
{
    public class RateController : GenericController<Rate>
    {
        public RateController()
        {
        }

        public RateController(ControllerObject other) : base(other)
        {
        }


        public override Task<Rate> UpdateAsync(Rate entity)
        {
            CheckEntity(entity);

            return base.UpdateAsync(entity);
        }

        public override Task<IEnumerable<Rate>> UpdateAsync(IEnumerable<Rate> entities)
        {
            foreach (var entity in entities)
            {
                CheckEntity(entity);
            }

            return base.UpdateAsync(entities);
        }

        public override Task<IEnumerable<Rate>> InsertAsync(IEnumerable<Rate> entities)
        {
            foreach (var entity in entities)
            {
                CheckEntity(entity);
            }
            return base.InsertAsync(entities);
        }

        public override Task<Rate> InsertAsync(Rate entity)
        {
            CheckEntity(entity);
            return base.InsertAsync(entity);
        }

        private void CheckEntity(Rate entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"Darf nicht null sein: {nameof(entity)}");


        }
    }
}
