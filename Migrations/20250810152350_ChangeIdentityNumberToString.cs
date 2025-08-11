using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityNumberToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("2a41d642-8948-4ece-8290-a0fde85dd591"));

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Ohs_Employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("419e4b74-1f03-43ed-ad30-0d0ed1d3b30b"), new DateTime(2025, 8, 10, 15, 23, 50, 736, DateTimeKind.Utc).AddTicks(2760), "admin@isg.com", "Sistem Admini", "$2a$11$BBC2KPUDOPeU8DlvgupKKuG7aBUCI/VltWbMVZ7x7LHm2.QpLuh9e", 1, new DateTime(2025, 8, 10, 15, 23, 50, 736, DateTimeKind.Utc).AddTicks(2760), new Guid("c38fe6cf-1e2e-4e7f-8d0f-2188513972d8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("419e4b74-1f03-43ed-ad30-0d0ed1d3b30b"));

            migrationBuilder.AlterColumn<int>(
                name: "IdentityNumber",
                table: "Ohs_Employees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("2a41d642-8948-4ece-8290-a0fde85dd591"), new DateTime(2025, 8, 10, 15, 16, 15, 750, DateTimeKind.Utc).AddTicks(5580), "admin@isg.com", "Sistem Admini", "$2a$11$ph65XD3YgikCMmSXc0eMf.SalXbBve0k9hT51XhNw2IkTOIagHm4G", 1, new DateTime(2025, 8, 10, 15, 16, 15, 750, DateTimeKind.Utc).AddTicks(5580), new Guid("126273ea-3712-489a-803a-53519fefb7fc") });
        }
    }
}
