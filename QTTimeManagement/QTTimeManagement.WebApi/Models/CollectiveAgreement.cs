namespace QTTimeManagement.WebApi.Models
{
    public class CollectiveAgreement : VadalityModelWithoutVersion
    {
        public string Name { get; set; } = string.Empty;

        #region nighthours
        public DateTime? NightHoursBegin { get; set; }
        public DateTime? NightHoursEnd { get; set; }
        #endregion

        #region break
        public TimeSpan? MaximumUnpaidBreakDuration { get; set; }

        public TimeSpan? MinWorkingTimeAfterBegin { get; set; }
        public TimeSpan? MinWorkingTimeBeforeEnd { get; set; }

        public TimeSpan? MinGreatBreakDuration { get; set; }
        public TimeSpan? MinTimeGreatBreakAfterBegin { get; set; }
        public TimeSpan? MinTimeGreatBreakBeforeEnd { get; set; }
        #endregion

        #region rest time
        
        #endregion

        #region operating time
        public TimeSpan? MaxOperatingTime { get; set; }
        public TimeSpan? MinOperatingTimeToPay { get; set; }
        public TimeSpan? PreperationAndPreworkTime { get; set; }
        #endregion

        #region overtime
        public int OverTimeThresholdWeeklyHours { get; set; }
        public double OvertimeSurchargeWeeklyHoursInPercent { get; set; }
        public double OvertimeSurchargeBeforWeeklyHourThresholdInPercent { get; set; }
        public double HolidaySurchargeInPercent { get; set; }
        #endregion

        #region diets
        public int MaxDietsPerDay { get; set; }
        public double DietRatePerDay { get; set; }
        #endregion
    }
}
