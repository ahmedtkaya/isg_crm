using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ReportTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("14c3777b-8f1b-499f-84db-23f584a6cf11"));

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportType = table.Column<string>(type: "text", nullable: false),
                    ReportDescription = table.Column<string>(type: "text", nullable: false),
                    ReportFileUrl = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ControlCheck = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Ohs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Ohs_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("c11c1fa2-39b6-472d-96df-9b84c1b32dce"), new DateTime(2025, 8, 16, 17, 32, 49, 383, DateTimeKind.Utc).AddTicks(6880), "admin@isg.com", "Sistem Admini", "$2a$11$8v8peXZGISUtawuRhDIrce14nSAMHUyPChkMCLtnRlhnYa7vgFjva", 1, new DateTime(2025, 8, 16, 17, 32, 49, 383, DateTimeKind.Utc).AddTicks(6880), new Guid("f3cb3c6e-8b32-458e-94be-9c6a70870bb6") });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CompanyId",
                table: "Reports",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("c11c1fa2-39b6-472d-96df-9b84c1b32dce"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("14c3777b-8f1b-499f-84db-23f584a6cf11"), new DateTime(2025, 8, 13, 18, 57, 53, 296, DateTimeKind.Utc).AddTicks(1750), "admin@isg.com", "Sistem Admini", "$2a$11$5jViKApjeFd7cU7a3veeTuKwzdERIrur/.imEk.8X0Iyq2JB1Zvcm", 1, new DateTime(2025, 8, 13, 18, 57, 53, 296, DateTimeKind.Utc).AddTicks(1750), new Guid("bf08c4fa-13bb-4afa-bf2b-4378ab12cc03") });
        }
    }
}
