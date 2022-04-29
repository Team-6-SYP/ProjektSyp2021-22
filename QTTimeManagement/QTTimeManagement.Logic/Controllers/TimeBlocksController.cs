using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.Logic.Controllers
{
    internal sealed class TimeBlocksController : GenericController<TimeBlock>
    {
        public TimeBlocksController() : base()
        {
        }

        public TimeBlocksController(ControllerObject other) : base(other)
        {
        }

        #region Get
        public override Task<TimeBlock[]> GetAllAsync()
        {
            return base.GetAllAsync();
        }
        public override ValueTask<TimeBlock?> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }
        #endregion

        #region Insert
        public override Task<IEnumerable<TimeBlock>> InsertAsync(IEnumerable<TimeBlock> entities)
        {
            return base.InsertAsync(entities);
        }
        public override Task<TimeBlock> InsertAsync(TimeBlock entity)
        {
            return base.InsertAsync(entity);
        }
        #endregion

        #region Update
        public override Task<IEnumerable<TimeBlock>> UpdateAsync(IEnumerable<TimeBlock> entities)
        {
            return base.UpdateAsync(entities);
        }
        public override Task<TimeBlock> UpdateAsync(TimeBlock entity)
        {
            return base.UpdateAsync(entity);
        }
        #endregion

        #region Delete
        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        #endregion
    }
}
