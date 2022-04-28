using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.Logic.Controllers
{
    public class ServiceTemplatesController : GenericController<ServiceTemplate>
    {
        public ServiceTemplatesController() : base()
        {
        }
        public ServiceTemplatesController(ControllerObject others) : base(others)
        {
        }

        #region Get
        public override Task<ServiceTemplate[]> GetAllAsync()
        {
            return base.GetAllAsync();
        }
        public override ValueTask<ServiceTemplate?> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }
        #endregion

        #region Insert
        public override Task<IEnumerable<ServiceTemplate>> InsertAsync(IEnumerable<ServiceTemplate> entities)
        {
            if (entities == null) throw new ArgumentNullException("Servicetemplate ist leer",nameof(entities));

            foreach (var item in entities)
            {
                if (item.Name == String.Empty) throw new ArgumentNullException("Name muss darf kein Leerstring sein", nameof(item));
            }

            return base.InsertAsync(entities);
        }
        public override Task<ServiceTemplate> InsertAsync(ServiceTemplate entity)
        {
            if (entity == null) throw new ArgumentNullException("ServiceTemplate darf nicht leer sein", nameof(entity));
            if (entity.Name == String.Empty) throw new ArgumentNullException("Der name des ServiceTemplate darf kein Leerstring sein", nameof(entity));
            return base.InsertAsync(entity);
        }
        #endregion

        #region Update
        public override Task<IEnumerable<ServiceTemplate>> UpdateAsync(IEnumerable<ServiceTemplate> entities)
        {
            if (entities == null) throw new ArgumentNullException("Update Async ServiceTemplate (null)", nameof(entities));
            foreach (var item in entities)
            {
                if (item.Name == String.Empty) throw new ArgumentException("Update Async ServiceTemplate Name ist Leerstring", nameof(item)); 
            }
 
            return base.UpdateAsync(entities);
        }
        public override Task<ServiceTemplate> UpdateAsync(ServiceTemplate entity)
        {
            if (entity == null) throw new ArgumentNullException("UpdateAsync ServiceTemplate (null)", nameof(entity));
            if (entity.Name == String.Empty) throw new ArgumentException("UpdateAsync ServiceTemplate Name hat Leerstring", nameof(entity));
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
