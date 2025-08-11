using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class CreateManagerManual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("2a41d642-8948-4ece-8290-a0fde85dd591"), new DateTime(2025, 8, 10, 15, 16, 15, 750, DateTimeKind.Utc).AddTicks(5580), "admin@isg.com", "Sistem Admini", "$2a$11$ph65XD3YgikCMmSXc0eMf.SalXbBve0k9hT51XhNw2IkTOIagHm4G", 1, new DateTime(2025, 8, 10, 15, 16, 15, 750, DateTimeKind.Utc).AddTicks(5580), new Guid("126273ea-3712-489a-803a-53519fefb7fc") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("2a41d642-8948-4ece-8290-a0fde85dd591"));
        }
    }
}
