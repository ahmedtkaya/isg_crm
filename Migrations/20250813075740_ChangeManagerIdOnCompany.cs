using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ChangeManagerIdOnCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Managers_ManagerId",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("de38e54c-098f-4ca6-a407-19be32e782c9"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Company",
                newName: "ManagerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ManagerId",
                table: "Company",
                newName: "IX_Company_ManagerId1");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("e697adea-a70a-4b9a-8df3-4ef2753c0ff4"), new DateTime(2025, 8, 13, 7, 57, 40, 341, DateTimeKind.Utc).AddTicks(8560), "admin@isg.com", "Sistem Admini", "$2a$11$HZuq783Bw.gm9nQrgVgvR.UqlT3VpKgM1Q/vwIbCkYleG25a12gcS", 1, new DateTime(2025, 8, 13, 7, 57, 40, 341, DateTimeKind.Utc).AddTicks(8560), new Guid("1cda0563-9b08-4627-be4b-cb17d1880a7f") });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Managers_ManagerId1",
                table: "Company",
                column: "ManagerId1",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Managers_ManagerId1",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("e697adea-a70a-4b9a-8df3-4ef2753c0ff4"));

            migrationBuilder.RenameColumn(
                name: "ManagerId1",
                table: "Company",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ManagerId1",
                table: "Company",
                newName: "IX_Company_ManagerId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Company",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("de38e54c-098f-4ca6-a407-19be32e782c9"), new DateTime(2025, 8, 13, 7, 41, 46, 647, DateTimeKind.Utc).AddTicks(6430), "admin@isg.com", "Sistem Admini", "$2a$11$sAoMjS/F4UrQ06dxWgGv/O0T6gGZKJnSe5gLJlpvP69Sq7CiNFEKS", 1, new DateTime(2025, 8, 13, 7, 41, 46, 647, DateTimeKind.Utc).AddTicks(6430), new Guid("5442ae8b-b532-41d7-b40e-8db5b62427f4") });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Managers_ManagerId",
                table: "Company",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
