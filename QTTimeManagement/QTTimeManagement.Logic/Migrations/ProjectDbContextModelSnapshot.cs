﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QTTimeManagement.Logic.DataContext;

#nullable disable

namespace QTTimeManagement.Logic.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.3.22175.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.CollectiveAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<double>("DietRatePerDay")
                        .HasColumnType("float");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<double>("HolidaySurchargeInPercent")
                        .HasColumnType("float");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxDietsPerDay")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("MaxOperatingTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MaximumUnpaidBreakDuration")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MinGreatBreakDuration")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MinOperatingTimeToPay")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MinTimeGreatBreakAfterBegin")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MinTimeGreatBreakBeforeEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MinWorkingTimeAfterBegin")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("MinWorkingTimeBeforeEnd")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("NightHoursBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NightHoursEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("OverTimeThresholdWeeklyHours")
                        .HasColumnType("int");

                    b.Property<double>("OvertimeSurchargeBeforWeeklyHourThresholdInPercent")
                        .HasColumnType("float");

                    b.Property<double>("OvertimeSurchargeWeeklyHoursInPercent")
                        .HasColumnType("float");

                    b.Property<TimeSpan?>("PreperationAndPreworkTime")
                        .HasColumnType("time");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Begin");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Begin", "Name")
                        .IsUnique();

                    b.ToTable("CollectiveAgreements", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BeginWorkingWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("DayOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double?>("TransferVacationDays")
                        .HasColumnType("float");

                    b.Property<double>("WeeklyHours")
                        .HasColumnType("float");

                    b.Property<int>("WorkingDaysPerWeek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Employees", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Holidays", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<double>("RateAmount")
                        .HasColumnType("float");

                    b.Property<int>("RateType")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Begin");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Begin", "RateType", "EmployeeId")
                        .IsUnique();

                    b.ToTable("Rates", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChangesThroughTemplateNotice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CollectiveAgreementId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompliant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSameAsTemplate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUpdatedThroughTemplate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NotCompliantNotice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ServiceDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceTemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollectiveAgreementId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceTemplateId");

                    b.ToTable("Services", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.ServiceTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Validitydays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Begin");

                    b.HasIndex("Name", "Begin")
                        .IsUnique();

                    b.ToTable("ServiceTemplates", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.TimeBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notice")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("OnCompanyTerrain")
                        .HasColumnType("bit");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("TimeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ServiceTemplateId");

                    b.ToTable("TimeBlocks", "timemanagement");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Rate", b =>
                {
                    b.HasOne("QTTimeManagement.Logic.Entities.Employee", "Employee")
                        .WithMany("Rates")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Service", b =>
                {
                    b.HasOne("QTTimeManagement.Logic.Entities.CollectiveAgreement", "CollectiveAgreement")
                        .WithMany("Services")
                        .HasForeignKey("CollectiveAgreementId");

                    b.HasOne("QTTimeManagement.Logic.Entities.Employee", "Employee")
                        .WithMany("Services")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QTTimeManagement.Logic.Entities.ServiceTemplate", "ServiceTemplate")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollectiveAgreement");

                    b.Navigation("Employee");

                    b.Navigation("ServiceTemplate");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.TimeBlock", b =>
                {
                    b.HasOne("QTTimeManagement.Logic.Entities.Service", "Service")
                        .WithMany("TimeBlocks")
                        .HasForeignKey("ServiceId");

                    b.HasOne("QTTimeManagement.Logic.Entities.ServiceTemplate", "ServiceTemplate")
                        .WithMany("TimeBlocks")
                        .HasForeignKey("ServiceTemplateId");

                    b.Navigation("Service");

                    b.Navigation("ServiceTemplate");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.CollectiveAgreement", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Employee", b =>
                {
                    b.Navigation("Rates");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.Service", b =>
                {
                    b.Navigation("TimeBlocks");
                });

            modelBuilder.Entity("QTTimeManagement.Logic.Entities.ServiceTemplate", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("TimeBlocks");
                });
#pragma warning restore 612, 618
        }
    }
}
