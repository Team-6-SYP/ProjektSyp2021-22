using QTTimeManagement.Logic.Entities;
using QTTimeManagement.Logic.Controllers;
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
            //using var empCtrl = new EmployeeController();
            //var employee = Task.Run(async () => await empCtrl.GetAllAsync());
            var employee = CreateEmployees();
            ////CreateDateData();

            ////CreateCollectiveAgreement();
            //using var templCtrl = new ServiceTemplatesController();
            //var templ = Task.Run(async () => await templCtrl.GetAllAsync());
            //templ.Wait();

            var templ = CreateServiceTemplates();
            var serviceInsert = CreateServices(employee, templ);

            var serviceGet = GetService(serviceInsert.Id);
            var templGet = GetTemplate(templ.Id);
            //UpdateService();
            //Console.WriteLine($"Service Get: {serviceGet}\n Service Insert: {serviceInsert}\n Template Get {templGet}\n Template Insert {templ}");


        }

        private static void UpdateService()
        {
            using var serviceCtrl = new ServicesController();
            using var templateCtrl = new ServiceTemplatesController();
            var templ =Task.Run(async()=> await templateCtrl.GetAllAsync());
            templ.Wait();
            var serviceList = Task.Run(async() => await serviceCtrl.GetallByTemplateId(templ.Result.FirstOrDefault().Id));
            serviceList.Wait();
            var serviceUpdate = new Service();
            serviceUpdate.CopyFrom(serviceList.Result.FirstOrDefault());
            var timeBlockList = new List<TimeBlock>();
            var tmp = new TimeBlock {
                ServiceId = serviceUpdate.Id,
                TimeType = Logic.Enumerations.TimeType.Preperation,
                Begin = new TimeSpan(0,0,0),
                End = new TimeSpan(1,0,0),
                OnCompanyTerrain=true,
                Notice = "Vorbereitung in der Zentrale" };
            timeBlockList.Add(tmp);
            tmp = new TimeBlock {
                ServiceId = serviceUpdate.Id,
                TimeType = Logic.Enumerations.TimeType.Operation,
                End = new TimeSpan(5, 0, 0),
                OnCompanyTerrain = false,
                Notice = "Fahrt bis zur Pause" };
            timeBlockList.Add(tmp);
            tmp = new TimeBlock {
                ServiceId = serviceUpdate.Id,
                TimeType = Logic.Enumerations.TimeType.Break,
                End = new TimeSpan(6, 0, 0),
                OnCompanyTerrain = true,
                Notice = "Pause nach 6h" };
            timeBlockList.Add(tmp);
            tmp = new TimeBlock {
                ServiceId = serviceUpdate.Id,
                TimeType = Logic.Enumerations.TimeType.Operation,
                End = new TimeSpan(8, 0, 0),
                OnCompanyTerrain = false,
                Notice = "Fahrt nach der Pause" };
            timeBlockList.Add(tmp);
            tmp = new TimeBlock {
                ServiceId = serviceUpdate.Id,
                TimeType = Logic.Enumerations.TimeType.Preperation,
                End = new TimeSpan(8, 15, 0),
                OnCompanyTerrain = true,
                Notice = "Nachberreitung in der Zentrale" };
            timeBlockList.Add(tmp);
            serviceUpdate.TimeBlocks = timeBlockList;
            var serviceAfterUpdate = Task.Run(async()=>await serviceCtrl.UpdateAsync(serviceUpdate));
            Task.Run(async () => await serviceCtrl.SaveChangesAsync()).Wait();
            serviceAfterUpdate.Wait();
            Console.WriteLine($"ServiceBeforeUpdate: {serviceUpdate} \n ServiceAfterUpdate. {serviceAfterUpdate}");
        }


        private static ServiceTemplate GetTemplate(int id)
        {
            using var templCtrl = new ServiceTemplatesController();

            var result = new ServiceTemplate();
            Task.Run(async () =>
            {
                result=await templCtrl.GetByIdAsync(id);
            }).Wait();
            return result;
        }

        private static Service GetService(int id)
        {
            using var serviceCtrl = new ServicesController();

            var result = new Service();
            Task.Run(async () =>
            {
               result = await serviceCtrl.GetByIdAsync(id);
            }).Wait();
            return result;
        }

        private static Service CreateServices(Employee emp, ServiceTemplate temp)
        {
            using var servicesCtrl = new Logic.Controllers.ServicesController();

            var service1 = new Service
            {
                Name = "Test1",
                ServiceType = Logic.Enumerations.ServiceType.Working,
                Notes = "Testdaten 1",
                ServiceDay = DateTime.Now,
                EmployeeId = emp.Id,
                ServiceTemplateId = temp.Id,
            };
            var result = new Service();
            Task.Run(async () =>
            {
                result = await servicesCtrl.InsertAsync(service1);
                await servicesCtrl.SaveChangesAsync();
            }).Wait();
            return result;
        }

        private static ServiceTemplate CreateServiceTemplates()
        {
            using var serviceTempCtrl = new Logic.Controllers.ServiceTemplatesController();
            var timeBlocks = new List<TimeBlock>();
            var tmp = new TimeBlock
            {
                TimeType = Logic.Enumerations.TimeType.Operation,
                Begin = new TimeSpan(0,0,0),
                End = new TimeSpan(5,0,0),
                OnCompanyTerrain = true,
                Notice = "Template 1 TimeBlock1"
            };
            timeBlocks.Add(tmp);
            var tmp2 = new TimeBlock
            {
                TimeType = Logic.Enumerations.TimeType.Operation,
                Begin = new TimeSpan(6, 0, 0),
                End = new TimeSpan(12, 0, 0),
                OnCompanyTerrain = true,
                Notice = "Template 1 TimeBlock1"
            };
            timeBlocks.Add(tmp2);
            var temp = new ServiceTemplate
            {
                Validitydays = Logic.Enumerations.Weekday.Friday,
                Name = "TestTemplate1",
                Notes = "Testdaten 1",
            };
            temp.TimeBlocks = timeBlocks;
            var result = new ServiceTemplate();
            Task.Run(async() =>
            {
                result = await serviceTempCtrl.InsertAsync(temp);
                await serviceTempCtrl.SaveChangesAsync();
            }).Wait();
            return result;
        }

        private static void CreateCollectiveAgreement()
        {
            var ca1 = new CollectiveAgreement()
            {
                Name = "Test101",
                Begin = DateTime.Now.AddDays(1),
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

            Task.Run(async () =>
            {
                await ctrl.InsertAsync(ca1);
                await ctrl.InsertAsync(ca3);
                await ctrl.InsertAsync(ca2);
                await ctrl.InsertAsync(ca4);
                await ctrl.SaveChangesAsync();
            }).Wait();
        }

        private static void CreateDateData()
        {
            var date1 = new DateTime();
            var date2 = new DateTime();

            var date3 = new DateTime();
            var date4 = new DateTime();


            date1 = date1.AddHours(23);
            date2 = date2.AddHours(30);

            date3 = date2;
            date4 = date3.AddHours(6);

            Console.WriteLine(new DateTime());
        }

        private static Employee CreateEmployees()
        {
            using var ctrl = new QTTimeManagement.Logic.Controllers.EmployeesController();
            var emp1 = new Employee()
            {
                DayOfBirth = new DateTime(1989, 6, 10),
                FirstName = "Max",
                LastName = "Müller",
                Gender = Logic.Enumerations.Gender.Pangender,
                Email = "m.mueller@gmx.at",

                HireDate = new DateTime(2010, 08, 8),
                WeeklyHours = 38.5,
                WorkingDaysPerWeek = 5,
                BeginWorkingWeek = Logic.Enumerations.Weekday.Monday,
                TransferVacationDays = 4.3,

            };


            Console.WriteLine(emp1);

            //Employee emp2 = new();
            var result = new Employee();
            Task.Run(async () =>
            {
                result = await ctrl.InsertAsync(emp1);
                //await ctrl.InsertAsync(emp2);
                await ctrl.SaveChangesAsync();
            }).Wait();
            Console.WriteLine(result);
            return result;
        }
    }
}
