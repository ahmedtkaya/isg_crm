using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class SeedManager2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("38cc51b3-41fc-4d4c-a791-6cc2c98e921a"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("43d0563d-96de-42a4-a79f-1bebaa967c40"), new DateTime(2025, 8, 10, 14, 10, 7, 627, DateTimeKind.Utc).AddTicks(4710), "admin@isg.com", "Sistem Admini", "$2a$11$nTEFBE2nLvTa43vwJ6jnZ.OPzcmSR7Df/WgJd83GpaCW3qKDlWatC", 1, new DateTime(2025, 8, 10, 14, 10, 7, 627, DateTimeKind.Utc).AddTicks(4710), new Guid("6e776394-1af5-4c4d-b373-3f7d8f2bc34d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("43d0563d-96de-42a4-a79f-1bebaa967c40"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("38cc51b3-41fc-4d4c-a791-6cc2c98e921a"), new DateTime(2025, 8, 10, 9, 45, 1, 613, DateTimeKind.Utc).AddTicks(8960), "admin@isg.com", "Sistem Yöneticisi", "$2a$11$PaJJon0daMjcZesLVEodUuLEVsqswecGZ/8laCjBFwvfaHQdpaX2G", 2, new DateTime(2025, 8, 10, 9, 45, 1, 613, DateTimeKind.Utc).AddTicks(8960), new Guid("1d737574-09fb-4d55-8f1b-3ac7c68fe0dd") });
        }
    }
}
