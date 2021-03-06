using QTTimeManagement.Logic.Entities;
using QTTimeManagement.Logic.Enumerations;
using QTTimeManagement.Logic.Modules.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Controllers
{
    public sealed class CollectiveAgreementsController : GenericValidityController<CollectiveAgreement>
    {
        private static TimeSpan OneDay => new TimeSpan(24, 0, 0);

        public CollectiveAgreementsController() : base()
        {
        }

        public CollectiveAgreementsController(ControllerObject other) : base(other)
        {
        }

        #region Validation Methods
        /// <summary>
        /// Validates all properties of the CollectiveAgreement if they set
        /// </summary>
        /// <param name="collectiveAgreement">Entity to valitate</param>
        public void ValidateCollectivAgreement(CollectiveAgreement collectiveAgreement)
        {
            ValidateNightHours(collectiveAgreement);
            ValidateBreakSettings(collectiveAgreement);
            ValidateMinOperatingTime(collectiveAgreement);
            ValidateMinOperatingTimeToPay(collectiveAgreement);
            ValidatePreperationAndPreworkTime(collectiveAgreement);
            ValidateOvertime(collectiveAgreement);
            ValitateDiet(collectiveAgreement);
        }

        private void ValitateDiet(CollectiveAgreement collectiveAgreement)
        {
            //public int MaxDietPerDay { get; set; }
            //public double DietRatePerDay { get; set; }

            if (collectiveAgreement.MaxDietsPerDay < 0)
                ThrowLogicException("Maximale Anzahl von Diäten pro Tag muss größer gleich 0 sein");

            if (collectiveAgreement.DietRatePerDay < 0)
                ThrowLogicException("Der max. Tageszuschlag für Diäten muss größer gleich 0 sein");
        }

        private void ValidateOvertime(CollectiveAgreement collectiveAgreement)
        {
            /*
            public int OverTimeThresholdWeeklyHours { get; set; }
            public double OvertimeSurchargeWeeklyHours { get; set; }
            public double OvertimeSurchargeBeforeWeeklyHourThreshold { get; set; }
            public double HolidaySurcharge { get; set; }
            */

            if (collectiveAgreement.OverTimeThresholdWeeklyHours < 0 ||
               collectiveAgreement.OverTimeThresholdWeeklyHours > 168)
                ThrowLogicException($"Der Wochenstundenschwellwert für Überstunden muss zwischen 0 und {168} liegen");

            if (collectiveAgreement.OvertimeSurchargeWeeklyHoursInPercent < 0)
                ThrowLogicException("Der Überstundenzuschlag muss gößer gleich 0 sein");

            if (collectiveAgreement.OvertimeSurchargeBeforWeeklyHourThresholdInPercent < 0)
                ThrowLogicException("Der Überstundenzuschlag vor erreichen des Wochenstundenschwellwerts muss gößer gleich 0 sein");

            if (collectiveAgreement.HolidaySurchargeInPercent < 0)
                ThrowLogicException("Der Feiertagszuschlag muss größer gleich 0 sein");
        }

        private void ValidatePreperationAndPreworkTime(CollectiveAgreement collectiveAgreement)
        {
            ValidateTimeSpan(collectiveAgreement.PreperationAndPreworkTime, "die min. Zeit für Vor- und Nacharbeitzeit");
        }

        private void ValidateMinOperatingTimeToPay(CollectiveAgreement collectiveAgreement)
        {
            ValidateTimeSpan(collectiveAgreement.MinOperatingTimeToPay, "die min. bezahlte Einsatzzeit");
        }

        private void ValidateMinOperatingTime(CollectiveAgreement collectiveAgreement)
        {
            //public TimeSpan? MaxOperatingTime { get; set; }

            ValidateTimeSpan(collectiveAgreement.MaxOperatingTime, "die max. Arbeitszeit");
        }

        private void ValidateBreakSettings(CollectiveAgreement collectiveAgreement)
        {
            /*
            public TimeSpan? MaximumBreakDuration { get; set; }

            public TimeSpan? MinWorkingTimeAfterBegin { get; set; }
            public TimeSpan? MinWorkingTimeBeforeEnd { get; set; }

            public TimeSpan? MinGreatBreak { get; set; }
            public TimeSpan? MinTimeGreatBreakAfterBegin { get; set; }
            public TimeSpan? MinTimeGreatBreakBeforeEnd { get; set; }
            */

            ValidateMaximumBreakDuration(collectiveAgreement);
            ValidateMinWorkingTime(collectiveAgreement);
            ValidateMinGreatBreakDuration(collectiveAgreement);
            ValidateMinWorkingTimeToGreatBreak(collectiveAgreement);

        }

        private void ValidateMinWorkingTime(CollectiveAgreement collectiveAgreement)
        {
            ValidateTwoBoundTimeSpans(collectiveAgreement.MinWorkingTimeAfterBegin,
                                     collectiveAgreement.MinWorkingTimeBeforeEnd,
                                     "die min. Zeit nach Arbeitsbeginn", "die min. Zeit vor Arbeitsende");
        }

        private void ValidateMaximumBreakDuration(CollectiveAgreement collectiveAgreement)
        {
            ValidateTimeSpan(collectiveAgreement.MaximumUnpaidBreakDuration, "die max. unbezahlte Pause");
        }

        private void ValidateMinGreatBreakDuration(CollectiveAgreement collectiveAgreement)
        {
            ValidateTimeSpan(collectiveAgreement.MinGreatBreakDuration, "den größen Pausenteil");
        }

        private void ValidateMinWorkingTimeToGreatBreak(CollectiveAgreement collectiveAgreement)
        {
            ValidateTwoBoundTimeSpans(collectiveAgreement.MinTimeGreatBreakAfterBegin,
                                      collectiveAgreement.MinWorkingTimeBeforeEnd,
                                      "di min. Zeit nach Arbeitsbeginn", "die min. Zeit vor Arbeitsende");
        }

        private void ValidateTimeSpan(TimeSpan? ts, string errorname)
        {
            if (ts == null)
                return;

            if (ts < TimeSpan.Zero)
                ThrowLogicException($"Zeitspanne für {errorname} muss größer als 0 sein");

            if (ts > OneDay)
                ThrowLogicException($"Zeitspanne für {errorname} kann nicht länger als einen Tag dauern");
        }

        private void ValidateTwoBoundTimeSpans(TimeSpan? ts1, TimeSpan? ts2, string errorname1, string errorname2)
        {
            if (ts1 == null && ts2 == null)
                return;

            if (ts1 == null || ts2 == null)
                ThrowLogicException($"Sowohl {errorname1} als auch {errorname2} müssen einen Wert haben");

            ValidateTimeSpan(ts1, errorname1);
            ValidateTimeSpan(ts2, errorname2);
        }

        private void ValidateNightHours(CollectiveAgreement collectiveAgreement)
        {
            /*
            public DateTime? NightHoursBegin { get; set; }
            public DateTime? NightHoursEnd { get; set; }
            */

            if (collectiveAgreement.NightHoursBegin == null && collectiveAgreement.NightHoursEnd == null)
                return;

            if (collectiveAgreement.NightHoursBegin == null || collectiveAgreement.NightHoursEnd == null)
                ThrowLogicException("Nachtstundenbeginn und -ende müssen gesetzt werden");

            if (collectiveAgreement.NightHoursBegin > collectiveAgreement.NightHoursEnd)
                ThrowLogicException("Der Beginn der Nachtstunden muss vor dem Ende liegen");

            if (collectiveAgreement.NightHoursEnd - collectiveAgreement.NightHoursBegin > OneDay)
                ThrowLogicException("Nachtstunde können nicht länger als 24 Stunden dauern.");
        }

        private void ThrowLogicException(string msg)
        {
            throw new LogicException(msg);
        }
        #endregion

        #region CRUD-Methods (Validation)
        protected override void BeforeActionExecute(ActionType actionType, CollectiveAgreement entity)
        {
            if (actionType == ActionType.Insert || actionType == ActionType.Update)
            {
                ValidateCollectivAgreement(entity);
            }

            entity.LastModified = DateTime.Now;

            base.BeforeActionExecute(actionType, entity);
        }
        #endregion

        #region CheckServices
        public async Task<bool> CheckServiceAsync(Service service)
        {
            //var collectiveAgreement = await EntitySet.OrderByDescending(ca => ca.Begin)
            //                            .FirstOrDefaultAsync(ca => ca.Begin <= service.ServiceDay).ConfigureAwait(false);

            var collectiveAgreement = await GetByDateTimeAsync(service.ServiceDay);

            if (collectiveAgreement == null)
            {
                return service.IsCompliant = false;
            }

            service.CollectiveAgreementId = collectiveAgreement.Id;

            var newNotice = CreateTagForNotice(collectiveAgreement);

            newNotice = newNotice.AddLastLine($"Do some Checking {someCount++}");

            newNotice = newNotice.AddLastLine(CreateEndTag(collectiveAgreement));

            AddNoticeToService(service, newNotice);

            return service.IsCompliant = true; //bei check ändern

        }

        private int someCount = 0;

        private string[] GetLastNotice(Service service)
        {
            if (service.CompliantNotice == null)
                return Array.Empty<string>();

            var lines = service.CompliantNotice.Split("\n");
            var result = new List<string>();

            var adding = false;

            foreach (var line in lines)
            {
                if(line.StartsWith(StartTag))
                    adding = true;

                if(adding)
                    result.Add(line);

                if (line.EndsWith(EndTag))
                    break;
            }
            return result.ToArray();
        }

        private const string StartTag = "#Id";
        private const string EndTag = "#End";

        private string CreateTagForNotice(CollectiveAgreement collectiveAgreement)
        {
            return $"{DateTime.UtcNow}\n{StartTag}: {collectiveAgreement.Id} {collectiveAgreement.Name}";
        }

        private string CreateEndTag(CollectiveAgreement collectiveAgreement)
        {
            return $"{EndTag}: {collectiveAgreement.Name}\n";
        }

        private void AddNoticeToService(Service service, string newNotice)
        {
            if(service.CompliantNotice == null)
            {
                service.CompliantNotice = newNotice;
                return;
            }

            var lastNotice = GetLastNotice(service);

            var newNoticeArray = newNotice.Split("\n");

            //Console.WriteLine(lastNotice.Count() + " " + newNoticeArray.Count());

            if (lastNotice.Count() != newNoticeArray.Count()-1)
            {
                service.CompliantNotice = service.CompliantNotice!.AddFirstLine(newNotice);
                return;
            }

            var count = 1;
            
            foreach (var line in lastNotice)
            {
                if (line != newNoticeArray[count])
                {
                    service.CompliantNotice = service.CompliantNotice!.AddFirstLine(newNotice);
                    return;
                }
                count++;
            }
        }
        #endregion

    }
}
