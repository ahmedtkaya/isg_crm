using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class AddManagerIdToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("ac7edb29-98ab-44ec-93b7-3bba044059e2"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("de38e54c-098f-4ca6-a407-19be32e782c9"), new DateTime(2025, 8, 13, 7, 41, 46, 647, DateTimeKind.Utc).AddTicks(6430), "admin@isg.com", "Sistem Admini", "$2a$11$sAoMjS/F4UrQ06dxWgGv/O0T6gGZKJnSe5gLJlpvP69Sq7CiNFEKS", 1, new DateTime(2025, 8, 13, 7, 41, 46, 647, DateTimeKind.Utc).AddTicks(6430), new Guid("5442ae8b-b532-41d7-b40e-8db5b62427f4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("de38e54c-098f-4ca6-a407-19be32e782c9"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("ac7edb29-98ab-44ec-93b7-3bba044059e2"), new DateTime(2025, 8, 11, 18, 54, 44, 317, DateTimeKind.Utc).AddTicks(1970), "admin@isg.com", "Sistem Admini", "$2a$11$yIqSK6cS8XNPBmrM1oJyZeYfWnPCSL/JQlNV1f4u6U9lPEcIXUJBS", 1, new DateTime(2025, 8, 11, 18, 54, 44, 317, DateTimeKind.Utc).AddTicks(1970), new Guid("5fc25ed2-f746-4735-adfe-6e05f6c7a131") });
        }
    }
}
