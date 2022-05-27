using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.Logic.Controllers
{
    public sealed class ServiceTemplatesController : GenericController<ServiceTemplate>
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
        public override async ValueTask<ServiceTemplate?> GetByIdAsync(int id)
        {
            var result= await base.GetByIdAsync(id);

            if (result == null) throw new Modules.Exceptions.LogicException($"The template with the Id {id}, cannot be found.");

            result.Services = await GetServicesAsync(result);
            result.TimeBlocks = await GetTimBlocksAsync(result);
            return result;
        }
        #endregion

        #region Insert
        public override async Task<IEnumerable<ServiceTemplate>> InsertAsync(IEnumerable<ServiceTemplate> entities)
        {
            var result = new List<ServiceTemplate>();
            foreach (var item in entities)
            {
                var tmp = await InsertAsync(item);
                result.Add(tmp);
            }
            return result;
        }
        public override async Task<ServiceTemplate> InsertAsync(ServiceTemplate entity)
        {
            CheckEntity(entity);
            var result = await base.InsertAsync(entity);
            await SaveChangesAsync();                       // TimeBlocksWerden bereits hier mit angelegt
            //result.TimeBlocks = InsertTimBlocksAsync(result);
            return result;
        }   
        #endregion

        #region Update
        public override async Task<IEnumerable<ServiceTemplate>> UpdateAsync(IEnumerable<ServiceTemplate> entities)
        {
            //Check if update allowed
            //Timeblock update
            CheckEntity(entities);
            var result = new List<ServiceTemplate>();
            foreach (var item in entities)
            {
                var tmp = await UpdateAsync(item);
                result.Add(item);
            }
            return result;
        }
        public override async Task<ServiceTemplate> UpdateAsync(ServiceTemplate entity)
        {
            //Check if update allowed
            //Timeblock update
            CheckEntity(entity);
            var result = await base.UpdateAsync(entity);
            result.TimeBlocks = await UpdateTimeBlocksAsync(entity);
            result.Services = await UpdateServicesAsync(entity);
            return result;
        }
        #endregion

        #region Delete
        public override async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) throw new Modules.Exceptions.LogicException($"The template with the id {id} cannot be found");
            entity.Services = await GetServicesAsync(entity);
            if (entity.Services == null) throw new Modules.Exceptions.LogicException($"The template with the id {id} cannot be deleted, because their are some services with the templateId left");
            await base.DeleteAsync(id);
        }
        #endregion

        #region CheckEntities
        public void CheckEntity(ServiceTemplate entity)
        {
            if (entity == null) throw new ArgumentNullException("ServicesController Null Exception", nameof(entity));
            if (entity.Validitydays == Enumerations.Weekday.None) throw new Modules.Exceptions.LogicException($"The validity day must be set");
            if (entity.Name == string.Empty) throw new Modules.Exceptions.LogicException("ServicesController Service Name ist Leerstring");
        }
        public void CheckEntity(IEnumerable<ServiceTemplate> entities)
        {
            foreach (var item in entities)
            {
                CheckEntity(item);
            }
        }
        #endregion

        #region GetServices
        private async Task<IEnumerable<Service>> GetServicesAsync(ServiceTemplate template)
        {
            using var serviceCtrl = new ServicesController(this);
            var tmp = await serviceCtrl.GetallByTemplateId(template.Id);
            return tmp;
        }
        #endregion

        #region UpdateService
        private async Task<IEnumerable<Service>> UpdateServicesAsync(ServiceTemplate entity)
        {
            using var servicesCtrl = new ServicesController(this);
            var result = await servicesCtrl.UpdateServiceTemplateAsync(entity);
            await servicesCtrl.SaveChangesAsync();
            return result;
        }
        #endregion

        #region GetTimeBlocks
        private async Task<IEnumerable<TimeBlock>> GetTimBlocksAsync(ServiceTemplate template)
        {
            using var timeBlockCtrl = new TimeBlocksController(this);
            var result = await timeBlockCtrl.GetByTemplateIdAsync(template.Id);
            return result;
        }
        #endregion

        #region InsertTimeBlocks
        private IEnumerable<TimeBlock> InsertTimBlocksAsync(ServiceTemplate template)
        {
            using var timeBlocksCtrl = new TimeBlocksController(this);
            var result = new List<TimeBlock>();
            
            foreach (var timeBlock in template.TimeBlocks)
            {
                var tmp = new TimeBlock();
                tmp.CopyFrom(timeBlock);
                tmp.ServiceTemplateId = template.Id;
                Task.Run(async () =>
                {
                    tmp = await timeBlocksCtrl.InsertAsync(tmp);
                    await timeBlocksCtrl.SaveChangesAsync();
                }).Wait();
                result.Add(tmp);
            }
            return result;
        }
        #endregion

        #region UpdateTimeBlocks
        private async Task<IEnumerable<TimeBlock>> UpdateTimeBlocksAsync(ServiceTemplate entity)
        {
            using var timeBlocksCtrl = new TimeBlocksController(this);

            var tmp = await timeBlocksCtrl.GetByTemplateIdAsync(entity.Id);
            if (tmp == null) return InsertTimBlocksAsync(entity);                 //Kann ein ServiceTemplate ohne TimeBlock erstellt werden??
            var result = await timeBlocksCtrl.UpdateAsync(entity.TimeBlocks);
            await timeBlocksCtrl.SaveChangesAsync();
            return result;
        }
        #endregion
    }
}
