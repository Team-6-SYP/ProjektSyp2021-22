﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QTTimeManagement.Logic.Migrations
{
    public partial class intitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "timemanagement");

            migrationBuilder.CreateTable(
                name: "CollectiveAgreements",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NightHoursBegin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NightHoursEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaximumBreakDuration = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinWorkingTimeAfterBegin = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinWorkingTimeBeforeEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinTime30MinBreakAfterBegin = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinTime30MinBreakBeforeEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    MaxOperatingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinWorkingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    PreperationAndPreworkTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    OverTimeThresholdWeeklyHours = table.Column<int>(type: "int", nullable: true),
                    OvertimeSurchargeWeeklyHours = table.Column<double>(type: "float", nullable: true),
                    OvertimeSurchargeBeforeWeeklyHourThreshold = table.Column<double>(type: "float", nullable: true),
                    HolidaySurcharge = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectiveAgreements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeeklyHours = table.Column<double>(type: "float", nullable: false),
                    WorkingDaysPerWeek = table.Column<int>(type: "int", nullable: false),
                    BeginWorkingWeek = table.Column<int>(type: "int", nullable: false),
                    TransferVacationDays = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DayOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTemplates",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Validitydays = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateType = table.Column<int>(type: "int", nullable: false),
                    RateAmount = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "timemanagement",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ServiceDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotCompliant = table.Column<bool>(type: "bit", nullable: false),
                    NotCompliantNotice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ServiceTemplateId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "timemanagement",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTemplates_ServiceTemplateId",
                        column: x => x.ServiceTemplateId,
                        principalSchema: "timemanagement",
                        principalTable: "ServiceTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeBlocks",
                schema: "timemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ServiceTemplateId = table.Column<int>(type: "int", nullable: true),
                    TimeType = table.Column<int>(type: "int", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeBlocks_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "timemanagement",
                        principalTable: "Services",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeBlocks_ServiceTemplates_ServiceTemplateId",
                        column: x => x.ServiceTemplateId,
                        principalSchema: "timemanagement",
                        principalTable: "ServiceTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                schema: "timemanagement",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_EmployeeId",
                schema: "timemanagement",
                table: "Rates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeId",
                schema: "timemanagement",
                table: "Services",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTemplateId",
                schema: "timemanagement",
                table: "Services",
                column: "ServiceTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTemplates_Name_Begin",
                schema: "timemanagement",
                table: "ServiceTemplates",
                columns: new[] { "Name", "Begin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_ServiceId",
                schema: "timemanagement",
                table: "TimeBlocks",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_ServiceTemplateId",
                schema: "timemanagement",
                table: "TimeBlocks",
                column: "ServiceTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectiveAgreements",
                schema: "timemanagement");

            migrationBuilder.DropTable(
                name: "Holidays",
                schema: "timemanagement");

            migrationBuilder.DropTable(
                name: "Rates",
                schema: "timemanagement");

            migrationBuilder.DropTable(
                name: "TimeBlocks",
                schema: "timemanagement");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "timemanagement");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "timemanagement");

            migrationBuilder.DropTable(
                name: "ServiceTemplates",
                schema: "timemanagement");
        }
    }
}
