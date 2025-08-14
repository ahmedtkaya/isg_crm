using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAddedOnAssigneesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("9de484a5-54c0-4751-98d2-7ff682625d00"));

            migrationBuilder.AddColumn<Guid>(
                name: "Ohs_EmployeeId",
                table: "Assignees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("5a59cd2f-014d-46fb-a669-8a3471ea4b07"), new DateTime(2025, 8, 13, 18, 41, 53, 159, DateTimeKind.Utc).AddTicks(4840), "admin@isg.com", "Sistem Admini", "$2a$11$eJVivn9OoZlaj/.3bM6BO.SB/bs6iJGkR9RbSDz6fGXrQgfKogxLq", 1, new DateTime(2025, 8, 13, 18, 41, 53, 159, DateTimeKind.Utc).AddTicks(4840), new Guid("5cd89e23-b504-4daf-a677-13bb24a7f729") });

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_CompanyId",
                table: "Assignees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_Ohs_EmployeeId",
                table: "Assignees",
                column: "Ohs_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Company_CompanyId",
                table: "Assignees",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Ohs_Employees_Ohs_EmployeeId",
                table: "Assignees",
                column: "Ohs_EmployeeId",
                principalTable: "Ohs_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Company_CompanyId",
                table: "Assignees");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Ohs_Employees_Ohs_EmployeeId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_CompanyId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_Ohs_EmployeeId",
                table: "Assignees");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("5a59cd2f-014d-46fb-a669-8a3471ea4b07"));

            migrationBuilder.DropColumn(
                name: "Ohs_EmployeeId",
                table: "Assignees");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("9de484a5-54c0-4751-98d2-7ff682625d00"), new DateTime(2025, 8, 13, 13, 43, 15, 763, DateTimeKind.Utc).AddTicks(3030), "admin@isg.com", "Sistem Admini", "$2a$11$V5iBwhiAzQa7G0grcevOwefk0Zye3dY3stuOdKEvITQWsyafTx3KS", 1, new DateTime(2025, 8, 13, 13, 43, 15, 763, DateTimeKind.Utc).AddTicks(3030), new Guid("2c304005-8ecb-4f49-8059-d646914c6175") });
        }
    }
}
