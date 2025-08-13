using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class FixCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("13b1aed6-74e1-4082-a686-9fcce635e727"), new DateTime(2025, 8, 13, 8, 1, 20, 84, DateTimeKind.Utc).AddTicks(1920), "admin@isg.com", "Sistem Admini", "$2a$11$y/.WRvGhGZB9OklYqwNtkeM9Z7vu0PHtbinuigbAC5j7S5/RobMGG", 1, new DateTime(2025, 8, 13, 8, 1, 20, 84, DateTimeKind.Utc).AddTicks(1930), new Guid("06e52067-7bd6-453a-885f-519ed15ca66b") });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Managers_ManagerId",
                table: "Company",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Managers_ManagerId",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("13b1aed6-74e1-4082-a686-9fcce635e727"));

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
    }
}
