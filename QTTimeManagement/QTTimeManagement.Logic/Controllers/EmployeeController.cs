using QTTimeManagement.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Controllers
{
    public sealed class EmployeeController : GenericController<Employee>
    {
        #region Constructor
        public EmployeeController()
        {
        }

        public EmployeeController(ControllerObject other) : base(other)
        {
        }
        #endregion Constructor

        #region Basic GRUD 

        #region Get
        public override Task<Employee[]> GetAllAsync()
        {
            return base.GetAllAsync();
        }
        public override ValueTask<Employee?> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }
        #endregion Get

        #region Insert
        public override Task<Employee> InsertAsync(Employee entity)
        {
            CheckEntity(entity);
            return base.InsertAsync(entity);
        }

        public override Task<IEnumerable<Employee>> InsertAsync(IEnumerable<Employee> entities)
        {
            foreach (var entity in entities)
            {
                CheckEntity(entity);
            }
            return base.InsertAsync(entities);
        }
        #endregion Insert

        #region Update
        public override Task<Employee> UpdateAsync(Employee entity)
        {
            CheckEntity(entity);
            return base.UpdateAsync(entity);
        }
        public override Task<IEnumerable<Employee>> UpdateAsync(IEnumerable<Employee> entities)
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
        private void CheckEntity(Employee entity)
        {
            if (!entity.Email.Contains('@'))
                throw new Logic.Modules.Exceptions.LogicException($"Die Email Adresse {entity.Email} ist ungültig!!");
            
            if (entity.FirstName == string.Empty || entity.LastName == string.Empty )
                throw new Logic.Modules.Exceptions.LogicException($"Es muss ein vollständiger Name angegeben werden.");


        }
        #endregion Entity Check
    }
}
