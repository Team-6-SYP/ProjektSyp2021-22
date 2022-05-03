using QTTimeManagement.Logic.Entities;
using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Controllers
{
    public abstract class GenericValidityController<TEntity> : GenericController<TEntity>
        where TEntity : ValidityEntity<TEntity>, new()
    {
        protected GenericValidityController() : base()
        {
        }

        protected GenericValidityController(ControllerObject other) : base(other)
        {
        }

        private IEnumerable<TEntity>? currentData = null;

        public IEnumerable<TEntity> CurrentData
        {
            get
            {
                if(currentData == null)
                {
                    currentData = EntitySet.AsEnumerable().Where(e => e.VadilityPredicate(e)).ToList();
                }

                return currentData;
            }
        }

        private void SetEndDatesInsertAndUpdate(TEntity entity, Predicate<TEntity> predicate)
        {
            var database = CurrentData;

            var orderedSubSet = EntitySet.Local.Where(e => predicate(e)).OrderBy(e => e.Begin).ToList();

            var previous = orderedSubSet.LastOrDefault(e => e.Begin < entity.Begin);
            var next = orderedSubSet.FirstOrDefault(e => e.Begin > entity.Begin);

            if(previous != null)
            {
                previous.End = entity.Begin.AddDays(-1);
            }

            if(next != null)
            {
                entity.End = next.Begin.AddDays(-1);
            }
        }

        private void SetEndDatesDelete(TEntity entity, Predicate<TEntity> predicate)
        {
            var database = CurrentData;

            var orderedSubSet = EntitySet.Local.Where(e => predicate(e)).OrderBy(e => e.Begin).ToList();

            var previous = orderedSubSet.LastOrDefault(e => e.Begin < entity.Begin);
            var next = orderedSubSet.FirstOrDefault(e => e.Begin > entity.Begin);

            if (previous != null && next != null)
            {
                previous.End = next.Begin.AddDays(-1);
            }
            else if(previous != null && next == null)
            {
                previous.End = null;
            }  
        }

        protected override void BeforeActionExecute(ActionType actionType, TEntity entity)
        {
            if(actionType == ActionType.Insert || actionType == ActionType.Update)
            {
                SetEndDatesInsertAndUpdate(entity, entity.VadilityPredicate);          
            }

            if (actionType == ActionType.Delete)
            {
                SetEndDatesDelete(entity, entity.VadilityPredicate);
            }

            base.BeforeActionExecute(actionType, entity);
        }
    }
}
