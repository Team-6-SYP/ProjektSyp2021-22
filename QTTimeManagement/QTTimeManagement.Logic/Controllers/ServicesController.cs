using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.Logic.Controllers
{
    public sealed class ServicesController : GenericController<Service>
    {
        public ServicesController() : base()
        {
        }
        public ServicesController(ControllerObject other) : base(other)
        { 
        }

        #region Get
        public override Task<Service[]> GetAllAsync()
        {
            //loading Timeblocks --> if not differ form Template --> load Template
            return base.GetAllAsync();
        }
        public override ValueTask<Service?> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);   
        }
        #endregion

        #region Insert
        public override Task<IEnumerable<Service>> InsertAsync(IEnumerable<Service> entities)
        {
            //if timeblocks differs form Template --> save copy
            //else only ref Template
            CheckEntity(entities);
            return base.InsertAsync(entities);
        }
        public override Task<Service> InsertAsync(Service entity)
        {
            CheckEntity(entity);

            return base.InsertAsync(entity);
        }
        #endregion

        #region Update
        public override Task<IEnumerable<Service>> UpdateAsync(IEnumerable<Service> entities)
        {
           
            CheckEntity(entities);
            return base.UpdateAsync(entities);
        }
        public override Task<Service> UpdateAsync(Service entity)
        {
            CheckEntity(entity);
            return base.UpdateAsync(entity);
        }
        #endregion

        #region Delete
        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        #endregion

        public void CheckEntity(Service entity)
        {
            if(entity == null) throw new ArgumentNullException("ServicesController Null Exception",nameof(entity));
            if (entity.Name == String.Empty) throw new ArgumentException("ServicesController Service Name ist Leerstring", nameof(entity));
        }
        public void CheckEntity(IEnumerable<Service> entities)
        {
            if(entities == null) throw new ArgumentNullException("ServicesController Null Exception",nameof(entities));
            foreach (var item in entities)
            {
                if(item.Name == String.Empty) throw new ArgumentException("ServicesController Service Name ist Leerstring", nameof(item));
            }
        }
    }
}
