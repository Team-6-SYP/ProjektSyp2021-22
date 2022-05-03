using QTTimeManagement.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Controllers
{
    public sealed class RateController : GenericValidityController<Rate>
    {

        #region Contructor
        public RateController()
        {
        }

        public RateController(ControllerObject other) : base(other)
        {
        }
        #endregion #region Contructor


        #region Basic GRUD 

        #region Get
        public override Task<Rate[]> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override ValueTask<Rate?> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }
        #endregion Get

        #region Insert
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
        #endregion Insert

        #region Update
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
        #endregion Update

        #region Delete
        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        #endregion Delete

        #endregion Basic GRUD


        #region Entity Check

        private void CheckEntity(Rate entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"Darf nicht null sein: {nameof(entity)}");


        }

        #endregion Entity Check
    }
}
