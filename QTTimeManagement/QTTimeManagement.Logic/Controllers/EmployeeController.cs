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

            return base.InsertAsync(entity);
        }

        public override Task<IEnumerable<Employee>> InsertAsync(IEnumerable<Employee> entities)
        {

            return base.InsertAsync(entities);
        }
        #endregion Insert

        #region Update
        public override Task<Employee> UpdateAsync(Employee entity)
        {

            return base.UpdateAsync(entity);
        }
        public override Task<IEnumerable<Employee>> UpdateAsync(IEnumerable<Employee> entities)
        {

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




        protected override void BeforeActionExecute(ActionType actionType, Employee entity)
        {
            if (actionType == ActionType.Insert)
            {
                CheckEntity(entity);
            }

            if (actionType == ActionType.Update)
            {
                if (entity.Services.Count() == 0)
                    throw new Modules.Exceptions.LogicException($"Werte dürfen nur geändert werden, wenn ein Service gesetzt wurde.");

                else
                    CheckEntity(entity);
            }

            base.BeforeActionExecute(actionType, entity);
        }


        #region Entity Check
        private void CheckEntity(Employee entity)
        {
            if (!entity.Email.Contains('@') && !entity.Email.Contains('.'))
                throw new Modules.Exceptions.LogicException($"Die Email Adresse {entity.Email} ist ungültig!!");

            if (entity.FirstName == string.Empty || entity.LastName == string.Empty)
                throw new Modules.Exceptions.LogicException($"Es muss ein vollständiger Name angegeben werden.");

            if (entity.DayOfBirth > DateTime.Now)
                throw new Modules.Exceptions.LogicException($"Das Geburtsdatum darf nicht in der Zukunft liegen.");

            if (entity.HireDate < entity.DayOfBirth)
                throw new Modules.Exceptions.LogicException($"Das Einstellungsdatum ist nicht korrekt.");

            if (entity.WorkingDaysPerWeek < 1 || entity.WorkingDaysPerWeek > 7)
                throw new Modules.Exceptions.LogicException($"Die Arbeitsage in der Woche müssen mindestens 1 und höchstens 7 sein.");

            if (entity.WeeklyHours < 0 || entity.WeeklyHours > 168)
                throw new Modules.Exceptions.LogicException($"Die Wochenstunden sind nicht korrekt");

            if (entity.BeginWorkingWeek == 0)
                throw new Modules.Exceptions.LogicException($"Es muss ein Tag gesetzt werden.");

            if (entity.TransferVacationDays < 0)
                throw new Modules.Exceptions.LogicException($"Es dürfen keinen negativen Urlaubstage transferiert werden.");

            if (entity.VacationDaysPerYear < 1 && entity.VacationDaysPerYear > 365)
                throw new Modules.Exceptions.LogicException($"Der Ulraubsanspruch muss richtig eingetragen werden.");


        }
        #endregion Entity Check




    }
}
