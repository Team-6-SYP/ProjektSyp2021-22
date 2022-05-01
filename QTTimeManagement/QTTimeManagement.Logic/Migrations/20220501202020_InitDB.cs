using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QTTimeManagement.Logic.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NightHoursBegin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NightHoursEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaximumUnpaidBreakDuration = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinWorkingTimeAfterBegin = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinWorkingTimeBeforeEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinGreatBreakDuration = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinTimeGreatBreakAfterBegin = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinTimeGreatBreakBeforeEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    MaxOperatingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    MinOperatingTimeToPay = table.Column<TimeSpan>(type: "time", nullable: true),
                    PreperationAndPreworkTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    OverTimeThresholdWeeklyHours = table.Column<int>(type: "int", nullable: false),
                    OvertimeSurchargeWeeklyHoursInPercent = table.Column<double>(type: "float", nullable: false),
                    OvertimeSurchargeBeforWeeklyHourThresholdInPercent = table.Column<double>(type: "float", nullable: false),
                    HolidaySurchargeInPercent = table.Column<double>(type: "float", nullable: false),
                    MaxDietsPerDay = table.Column<int>(type: "int", nullable: false),
                    DietRatePerDay = table.Column<double>(type: "float", nullable: false),
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ServiceTemplateId = table.Column<int>(type: "int", nullable: false),
                    IsSameAsTemplate = table.Column<bool>(type: "bit", nullable: false),
                    IsCompliant = table.Column<bool>(type: "bit", nullable: false),
                    NotCompliantNotice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectivAgreementId = table.Column<int>(type: "int", nullable: true),
                    IsUpdatedThroughTemplate = table.Column<bool>(type: "bit", nullable: false),
                    ChangesThroughTemplateNotice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectiveAgreementId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_CollectiveAgreements_CollectiveAgreementId",
                        column: x => x.CollectiveAgreementId,
                        principalSchema: "timemanagement",
                        principalTable: "CollectiveAgreements",
                        principalColumn: "Id");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnCompanyTerrain = table.Column<bool>(type: "bit", nullable: false),
                    Notice = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
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
                name: "IX_CollectiveAgreements_Begin",
                schema: "timemanagement",
                table: "CollectiveAgreements",
                column: "Begin");

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveAgreements_Begin_Name",
                schema: "timemanagement",
                table: "CollectiveAgreements",
                columns: new[] { "Begin", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveAgreements_Name",
                schema: "timemanagement",
                table: "CollectiveAgreements",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                schema: "timemanagement",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_Begin",
                schema: "timemanagement",
                table: "Rates",
                column: "Begin");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_Begin_RateType_EmployeeId",
                schema: "timemanagement",
                table: "Rates",
                columns: new[] { "Begin", "RateType", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_EmployeeId",
                schema: "timemanagement",
                table: "Rates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CollectiveAgreementId",
                schema: "timemanagement",
                table: "Services",
                column: "CollectiveAgreementId");

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
                name: "IX_ServiceTemplates_Begin",
                schema: "timemanagement",
                table: "ServiceTemplates",
                column: "Begin");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CollectiveAgreements",
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
