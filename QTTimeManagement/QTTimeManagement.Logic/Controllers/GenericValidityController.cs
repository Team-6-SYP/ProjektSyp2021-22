using QTTimeManagement.Logic.Entities;
using QTTimeManagement.Logic.Interfaces;
using QTTimeManagement.Logic.Modules.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<IEnumerable<TEntity>> GetRelatedDataAsync(Predicate<TEntity> predicate)
        {
            return Task.Run(() => {
                return EntitySet.AsEnumerable().Where(e => predicate(e));
            });
        }

        private async Task SetEndDatesInsertAndUpdateAsync(TEntity entity, Predicate<TEntity> predicate)
        {
            var database = await GetRelatedDataAsync(predicate).ConfigureAwait(false);

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

        private async Task SetEndDatesDeleteAsync(TEntity entity, Predicate<TEntity> predicate)
        {
            var database = await GetRelatedDataAsync(predicate).ConfigureAwait(false);

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
                Task.Run(async () =>
                {
                    await SetEndDatesInsertAndUpdateAsync(entity, entity.VadilityPredicate).ConfigureAwait(false);
                }).Wait();          
            }

            if (actionType == ActionType.Delete)
            {
                Task.Run(async () =>
                {
                    await SetEndDatesDeleteAsync(entity, entity.VadilityPredicate).ConfigureAwait(false);
                }).Wait();          
            }

            base.BeforeActionExecute(actionType, entity);
        }

        public async Task<TEntity?> GetByDateTimeAsync(DateTime date)
        {
            var result = new TEntity();

            result = await EntitySet.AsQueryable().OrderByDescending(e => e.Begin).FirstOrDefaultAsync(e => date.Date >= e.Begin.Date && (e.End == null ? true : date.Date <= e.End.Value.Date)).ConfigureAwait(false);

            return result;
        }
    }
}
