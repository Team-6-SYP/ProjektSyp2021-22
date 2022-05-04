using QTTimeManagement.Logic.Entities;
using QTTimeManagement.Logic.Interfaces;
using QTTimeManagement.Logic.Modules.Exceptions;
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

        public IEnumerable<TEntity> GetRelatedData(Predicate<TEntity> predicate)
        {
            return EntitySet.AsEnumerable().Where(e => predicate(e)).ToList();
        }

        private void SetEndDatesInsertAndUpdate(TEntity entity, Predicate<TEntity> predicate)
        {
            var database = GetRelatedData(predicate);

            var orderedSubSet = EntitySet.Local.Where(e => predicate(e)).OrderBy(e => e.Begin).ToList();

            var previous = orderedSubSet.LastOrDefault(e => e.Begin <= entity.Begin);
            var next = orderedSubSet.FirstOrDefault(e => e.Begin >= entity.Begin);

            if (previous != null)
            {
                CompareToEntityBegins(previous, entity);
                previous.End = entity.Begin.AddDays(-1);
            }

            if (next != null)
            {
                CompareToEntityBegins(entity, next);
                entity.End = next.Begin.AddDays(-1);
            }
        }

        private void CompareToEntityBegins(TEntity e1, TEntity e2)
        {
            if (e1.Begin.Date == e2.Begin.Date)
                throw new LogicException($"Es gibt bereits ein Element mit Gültigkeitsbeginn am {DateOnly.FromDateTime(e1.Begin)}");
        }

        private void SetEndDatesDelete(TEntity entity, Predicate<TEntity> predicate)
        {
            var database = GetRelatedData(predicate);

            var orderedSubSet = EntitySet.Local.Where(e => predicate(e)).OrderBy(e => e.Begin).ToList();

            var previous = orderedSubSet.LastOrDefault(e => e.Begin < entity.Begin);
            var next = orderedSubSet.FirstOrDefault(e => e.Begin > entity.Begin);

            if (previous != null && next != null)
            {
                previous.End = next.Begin.AddDays(-1);
            }
            else if (previous != null && next == null)
            {
                previous.End = null;
            }
        }

        protected override void BeforeActionExecute(ActionType actionType, TEntity entity)
        {
            if (actionType == ActionType.Insert || actionType == ActionType.Update)
            {
                SetEndDatesInsertAndUpdate(entity, entity.VadilityPredicate);
            }

            if (actionType == ActionType.Delete)
            {
                SetEndDatesDelete(entity, entity.VadilityPredicate);
            }

            base.BeforeActionExecute(actionType, entity);
        }

        public TEntity? GetByDateTimeAsync(DateTime date, Predicate<TEntity> predicate)
        {
            var database = GetRelatedData(predicate);

            return database.FirstOrDefault(e => date >= e.Begin && (e.End == null ? true : date <= e.End));
        }
    }
}
