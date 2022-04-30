using QTTimeManagement.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.ConApp
{
    partial class Program
    {
        static partial void BeforeRun()
        {
            //var date1 = new DateTime();
            //var date2 = new DateTime();

            //var date3 = new DateTime();
            //var date4 = new DateTime();


            //date1 = date1.AddHours(23);
            //date2 = date2.AddHours(30);

            //date3 = date2;
            //date4 = date3.AddHours(6);

            //Console.WriteLine(new DateTime());

            var ca = new CollectiveAgreement()
            {
                Name = "Test3",
                Begin = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                NightHoursBegin = DateTime.Now,
                NightHoursEnd = DateTime.Now.AddHours(4),
                MaximumUnpaidBreakDuration = new TimeSpan(1, 30, 0),
                MaxOperatingTime = new TimeSpan(12, 0, 0),
                MinGreatBreakDuration = new TimeSpan(0, 30, 0),
                MinOperatingTimeToPay = new TimeSpan(6, 30, 0),
                MinTimeGreatBreakAfterBegin = new TimeSpan(3, 0, 0),
                MinTimeGreatBreakBeforeEnd = new TimeSpan(3, 0, 0),
                MinWorkingTimeAfterBegin = new TimeSpan(2, 0, 0),
                MinWorkingTimeBeforeEnd = new TimeSpan(2, 0, 0),
                HolidaySurchargeInPercent = 100,
                OvertimeSurchargeBeforWeeklyHourThresholdInPercent = 25,
                OvertimeSurchargeWeeklyHoursInPercent = 50,
                OverTimeThresholdWeeklyHours = 40,
                PreperationAndPreworkTime = new TimeSpan(0, 25, 0),
            };

            using var ctrl = new Logic.Controllers.CollectiveAgreementsController();

            Task.Run(async () =>
            {
                await ctrl.InsertAsync(ca);
                await ctrl.SaveChangesAsync();
            }).Wait();


        }

    }
}
