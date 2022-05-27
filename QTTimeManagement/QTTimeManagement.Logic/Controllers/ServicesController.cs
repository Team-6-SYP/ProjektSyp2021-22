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

        #region CRUD
        #region Get
        public override async Task<Service[]> GetAllAsync()
        {
            var services = await base.GetAllAsync();
            CheckEntity(services);
            foreach(var service in services)
            {
                if (service.CollectiveAgreementId != null) service.CollectiveAgreement = GetCollectiveAgreementById((int)service.CollectiveAgreementId);
                service.Employee = GetEmployeeById(service.EmployeeId);
                service.ServiceTemplate = GetSeviceTemplate(service.ServiceTemplateId);
                if (service.IsSameAsTemplate == false) service.TimeBlocks = GetServiceTimeBlocks(service.Id);
                else service.TimeBlocks = service.ServiceTemplate.TimeBlocks.ToList();
            }
            return services;    
        }

        public Task<Service[]> GetallByTemplateId(int templateId)
        {
            return EntitySet.AsNoTracking().Where(e=> e.ServiceTemplateId == templateId).ToArrayAsync();
        }

        public override async ValueTask<Service?> GetByIdAsync(int id)
        {
            var service = await base.GetByIdAsync(id);
            if (service != null)
            {
                if(service.CollectiveAgreementId != null) service.CollectiveAgreement = GetCollectiveAgreementById((int)service.CollectiveAgreementId);
                service.Employee = GetEmployeeById(service.EmployeeId);
                service.ServiceTemplate = GetSeviceTemplate(service.ServiceTemplateId);
                if (service.IsSameAsTemplate == false) service.TimeBlocks = GetServiceTimeBlocks(service.Id);
                else service.TimeBlocks = service.ServiceTemplate.TimeBlocks.ToList();
            }
            return service;
        }
        #endregion

        #region Insert
        public override async Task<IEnumerable<Service>> InsertAsync(IEnumerable<Service> entities)
        {
            //if timeblocks differs form Template --> save copy
            //else only ref Template
            CheckEntity(entities);
            CheckTimeblocks(entities);
            
            var services = await base.InsertAsync(entities);

            return await AddTimeBlocksAsync(services);
            

        }
        public override async Task<Service> InsertAsync(Service entity)
        {
            CheckEntity(entity);
            CheckTimeblocks(entity);

            var service = await base.InsertAsync(entity);
            //var result = await AddTimeBlocksAsync(service);
            return service;
            
        }


        #endregion

        #region Update
        internal async Task<IEnumerable<Service>>? UpdateServiceTemplateAsync(ServiceTemplate entity)
        {
            var result = await EntitySet.Where(e=>e.ServiceTemplateId == entity.Id).ToArrayAsync();
            if (result.Length == 0) throw new Modules.Exceptions.LogicException($"Keine Service mit der TemplateId {entity.Id} gefunden");
            for (int i = 0; i < result.Length; i++)
            {
                result[i].IsUpdatedThroughTemplate = true;
                result[i].Notes += $", {entity.Notes}";
            }
            return await UpdateAsync(result);
        }
        public override async Task<IEnumerable<Service>> UpdateAsync(IEnumerable<Service> entities)
        {
            var result = new List<Service>();
            foreach (var item in entities)
            {
                var tmp = await UpdateAsync(item);
                result.Add(tmp);
            }
            return result;
        }
        public override async Task<Service> UpdateAsync(Service entity)
        {
            CheckEntity(entity);
            var check = await GetByIdAsync(entity.Id);
            if (check == null) throw new Modules.Exceptions.LogicException($"Der Service {entity.Name} mit der Id {entity.Id} konnte nicht gefunden werden");
            CheckTimeblocks(entity);
            if(entity.IsSameAsTemplate) return await base.UpdateAsync(entity);
            var tmp = await UpdateTimeBlock(entity);
            return await base.UpdateAsync(tmp);
        }


        #endregion

        #region Delete
        public override async Task DeleteAsync(int id)
        {
            var delete = await GetByIdAsync(id);
            if (delete == null) throw new Modules.Exceptions.LogicException($"Der Service mit der Id {id} ist nicht vorhanden.");
            if (delete.IsSameAsTemplate) await base.DeleteAsync(id);
            else
            {
                await DeleteTimeblocksAsync(delete);
                await base.DeleteAsync(id);
            }
        }

        
        #endregion

        #endregion

        #region CheckEntity
        public void CheckEntity(Service? entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity),"ServicesController Null Exception");
            if (entity.Name == string.Empty) throw new Modules.Exceptions.LogicException("ServicesController Service Name ist Leerstring");
        }
        public void CheckEntity(IEnumerable<Service> entities)
        {
            foreach (var item in entities)
            {
                CheckEntity(item);
            }
        }
        #endregion

        #region CheckTimeblocks
        private void CheckTimeblocks(IEnumerable<Service> entity)
        {
            foreach (var item in entity)
            {
                CheckTimeblocks(item);
            }
        }
        private async void CheckTimeblocks(Service entity)
        {
            using var templatectrl = new ServiceTemplatesController();

            var templateTimeBlocks = await templatectrl.GetByIdAsync(entity.ServiceTemplateId);

            if (templateTimeBlocks == null) throw new Modules.Exceptions.LogicException($"ServiceTemplate mit der Id{entity.ServiceTemplateId} wurde nicht gefunden");
            if (entity.TimeBlocks.Count() > 0)
            {
                foreach (var item in entity.TimeBlocks)
                {
                    if (templateTimeBlocks.TimeBlocks.Contains(item) == false)
                    {
                        entity.IsSameAsTemplate = false;
                    }
                }
            }
        }
        #endregion

        #region InsertNewTimeBlocks
        private async Task<IEnumerable<TimeBlock>> InsertServiceTimeblocksAsync(Service entity)
        {
            using var timeBlocksctrl = new TimeBlocksController(this);
            var timeBlocks = new List<TimeBlock>();

            foreach (var item in entity.TimeBlocks)
            {
                var tmp = new TimeBlock();
                tmp.CopyFrom(item);
                tmp.ServiceId = entity.Id;
                tmp.ServiceTemplateId = null;
                timeBlocks.Add(tmp);
            }

            var result = await timeBlocksctrl.InsertAsync(timeBlocks);
            await timeBlocksctrl.SaveChangesAsync();
            return result;
        }
        private async Task<IEnumerable<Service>> AddTimeBlocksAsync(IEnumerable<Service> entities)
        {
            var result = new List<Service>();
            foreach (var item in entities)
            {
                result.Add(await AddTimeBlocksAsync(item));
            }
            return result;
        }
        private async Task<Service> AddTimeBlocksAsync(Service entity)
        {
            var result = entity;
            if (entity.IsSameAsTemplate == false)
            {
                var tmp = await InsertServiceTimeblocksAsync(entity);
                result.TimeBlocks = tmp.ToList();
            }
            return result;
        }
        #endregion

        #region UpdateTimeBlock
        private async Task<Service> UpdateTimeBlock(Service entity)
        {
            using var timeBlocksCtrl = new TimeBlocksController(this);
            var check = await timeBlocksCtrl.GetByServiceIdAsync(entity.Id);
            var result = new Service();
            if (check == null)
            {
                result = await AddTimeBlocksAsync(entity);
                return result;
            }
            var tmpUpdate = await timeBlocksCtrl.UpdateAsync(entity.TimeBlocks);
            await timeBlocksCtrl.SaveChangesAsync();
            result.TimeBlocks = tmpUpdate.ToList();
            return result;
        }
        #endregion

        #region DeleteServiceTimeBlocks
        private async Task DeleteTimeblocksAsync(Service service)
        {
            using var timeBlocksCtrl = new TimeBlocksController(this);
            var check = await timeBlocksCtrl.GetByServiceIdAsync(service.Id);
            if(check != null)
            {
                foreach (var item in service.TimeBlocks)
                {
                    await timeBlocksCtrl.DeleteAsync(item.Id);
                }
                await timeBlocksCtrl.SaveChangesAsync();
            }
        }
        #endregion

        #region GetServiceTimeBlocks
        private IEnumerable<TimeBlock> GetServiceTimeBlocks(int serviceId)
        {
            using var timeBlockCtrl = new TimeBlocksController(this);

            return Task.Run(async () => await timeBlockCtrl.GetByServiceIdAsync(serviceId)).Result;

        }
        #endregion

        #region GetServiceTemplate
        private ServiceTemplate GetSeviceTemplate(int serviceTemplateId)
        {
            using var templateCtrl = new ServiceTemplatesController(this);

            return Task.Run(async () => await templateCtrl.GetByIdAsync(serviceTemplateId)).Result ?? throw new Modules.Exceptions.LogicException($"Das Template mit der {serviceTemplateId} wurde nicht gefunden");
        }
        #endregion

        #region GetEmployee
        private Employee GetEmployeeById(int employeeId)
        {
            using var employeeCtrl = new EmployeeController(this);

            return Task.Run(async() => await employeeCtrl.GetByIdAsync(employeeId)).Result ?? throw new Modules.Exceptions.LogicException($" Der Angestellte mit der {employeeId} wurde nicht gefunden");
        }
        #endregion

        #region GetCollectiveAgreement
        private CollectiveAgreement GetCollectiveAgreementById(int collectiveAgreementId)
        {
            using var collevtiveCtrl = new CollectiveAgreementsController(this);

            return Task.Run(async () => await collevtiveCtrl.GetByIdAsync(collectiveAgreementId)).Result ?? new CollectiveAgreement();
        }
        #endregion
    }
}
