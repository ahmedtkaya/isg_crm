using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeIdAddedOnMissionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("eb32c601-799c-4eaa-beef-7659173d9a7d"));

            migrationBuilder.AddColumn<Guid>(
                name: "Employee",
                table: "Missions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeIdId",
                table: "Missions",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("11e19216-f9ae-48a7-a770-a03a7618175f"), new DateTime(2025, 8, 21, 9, 3, 3, 962, DateTimeKind.Utc).AddTicks(530), "admin@isg.com", "Sistem Admini", "$2a$11$/ifAwBnyGLRQenKoWYItXeNcS.FrffChEg8gYNnj9opv43.rlcQum", 1, new DateTime(2025, 8, 21, 9, 3, 3, 962, DateTimeKind.Utc).AddTicks(530), new Guid("f6471e01-5269-4d36-9b50-597891ad59a6") });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_EmployeeIdId",
                table: "Missions",
                column: "EmployeeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Ohs_Employees_EmployeeIdId",
                table: "Missions",
                column: "EmployeeIdId",
                principalTable: "Ohs_Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Ohs_Employees_EmployeeIdId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_EmployeeIdId",
                table: "Missions");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("11e19216-f9ae-48a7-a770-a03a7618175f"));

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "EmployeeIdId",
                table: "Missions");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("eb32c601-799c-4eaa-beef-7659173d9a7d"), new DateTime(2025, 8, 21, 7, 44, 28, 845, DateTimeKind.Utc).AddTicks(8490), "admin@isg.com", "Sistem Admini", "$2a$11$j4z5olj3p0EQoMJjrpqdHukoizy/ZMR5awgRcooqiXJzWSh72pPTi", 1, new DateTime(2025, 8, 21, 7, 44, 28, 845, DateTimeKind.Utc).AddTicks(8490), new Guid("a7f8471e-f083-483e-bf1c-15fd11037a6d") });
        }
    }
}
