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
            // using var ctrl = new QTTimeManagement.Logic.Controllers.EmployeeController();
            //var emp1 = new Employee()
            //{
            //    DayOfBirth = new DateTime(1989, 6, 10),
            //    FirstName = "Max",
            //    LastName = "Müller",
            //    Gender = Logic.Enumerations.Gender.Pangender,
            //    Email = "m.mueller@gmx.at",

            //    HireDate = new DateTime(2010, 08, 8),
            //    WeeklyHours = 38.5,
            //    WorkingDaysPerWeek = 5,
            //    BeginWorkingWeek = Logic.Enumerations.Weekday.Monday,
            //    TransferVacationDays = 4.3 ,

            //};


            //Console.WriteLine(emp1);

            //Employee emp2 = new();

            //Task.Run(async () =>
            //{
            //    // await ctrl.InsertAsync(emp1);
            //    await ctrl.InsertAsync(emp2);
            //    await ctrl.SaveChangesAsync();
            //}).Wait();



            ////var date1 = new DateTime();
            ////var date2 = new DateTime();

            ////var date3 = new DateTime();
            ////var date4 = new DateTime();


            ////date1 = date1.AddHours(23);
            ////date2 = date2.AddHours(30);

            ////date3 = date2;
            ////date4 = date3.AddHours(6);

            ////Console.WriteLine(new DateTime());

            var ca1 = new CollectiveAgreement()
            {
                Name = "Test1",
                Begin = DateTime.Now.AddDays(-1),
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
                DietRatePerDay = 24,
                MaxDietsPerDay = 12
            };

            var ca2 = new CollectiveAgreement();
            ca2.CopyFrom(ca1);
            ca2.Name = "Test2";
            ca2.Begin = ca1.Begin.AddDays(1);

            var ca3 = new CollectiveAgreement();
            ca3.CopyFrom(ca1);
            ca3.Name = "Test3";
            ca3.Begin = ca1.Begin.AddDays(5);

            var ca4 = new CollectiveAgreement();
            ca4.CopyFrom(ca1);
            ca4.Name = "Test4";
            ca4.Begin = ca1.Begin.AddDays(4);

            using var ctrl = new Logic.Controllers.CollectiveAgreementsController();

            var service = new Service()
            {
                ServiceDay = DateTime.UtcNow
            };

            //Task.Run(async () =>
            //{
            //    await ctrl.InsertAsync(ca1);
            //    await ctrl.InsertAsync(ca3);
            //    await ctrl.InsertAsync(ca2);
            //    await ctrl.InsertAsync(ca4);
            //    await ctrl.SaveChangesAsync();
            //}).Wait();

            Console.WriteLine(service.CompliantNotice);

            Task.Run(async () =>
            {
                await ctrl.CheckServiceAsync(service);
            }).Wait();

            Console.WriteLine(service.CompliantNotice);

            Task.Run(async () =>
            {
                await ctrl.CheckServiceAsync(service);
            }).Wait();
            Console.WriteLine(service.CompliantNotice);
        }

    }
}
