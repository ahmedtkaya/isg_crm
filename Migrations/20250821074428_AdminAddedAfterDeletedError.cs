using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class AdminAddedAfterDeletedError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("eb32c601-799c-4eaa-beef-7659173d9a7d"), new DateTime(2025, 8, 21, 7, 44, 28, 845, DateTimeKind.Utc).AddTicks(8490), "admin@isg.com", "Sistem Admini", "$2a$11$j4z5olj3p0EQoMJjrpqdHukoizy/ZMR5awgRcooqiXJzWSh72pPTi", 1, new DateTime(2025, 8, 21, 7, 44, 28, 845, DateTimeKind.Utc).AddTicks(8490), new Guid("a7f8471e-f083-483e-bf1c-15fd11037a6d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("eb32c601-799c-4eaa-beef-7659173d9a7d"));
        }
    }
}
