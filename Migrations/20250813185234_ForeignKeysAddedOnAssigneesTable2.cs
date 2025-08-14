using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAddedOnAssigneesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Ohs_Employees_Ohs_EmployeeId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_Ohs_EmployeeId",
                table: "Assignees");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("d2203d3e-4301-41c3-b383-4233f8cd0ffb"));

            migrationBuilder.DropColumn(
                name: "Ohs_EmployeeId",
                table: "Assignees");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("26b51a77-94c5-4d0c-945a-0245cf7cafdd"), new DateTime(2025, 8, 13, 18, 52, 34, 125, DateTimeKind.Utc).AddTicks(8350), "admin@isg.com", "Sistem Admini", "$2a$11$.rqU0bxtqMQfHAf1cL8cfOp7klX4U6v99aBVRkzm35Ta9F4OzZSvq", 1, new DateTime(2025, 8, 13, 18, 52, 34, 125, DateTimeKind.Utc).AddTicks(8350), new Guid("7a1c8dd7-c4e4-4796-81e2-bf017076f9dd") });

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_EmployeeId",
                table: "Assignees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Ohs_Employees_EmployeeId",
                table: "Assignees",
                column: "EmployeeId",
                principalTable: "Ohs_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Ohs_Employees_EmployeeId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_EmployeeId",
                table: "Assignees");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("26b51a77-94c5-4d0c-945a-0245cf7cafdd"));

            migrationBuilder.AddColumn<Guid>(
                name: "Ohs_EmployeeId",
                table: "Assignees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("d2203d3e-4301-41c3-b383-4233f8cd0ffb"), new DateTime(2025, 8, 13, 18, 48, 42, 517, DateTimeKind.Utc).AddTicks(4000), "admin@isg.com", "Sistem Admini", "$2a$11$A/R8XaQ7IWk/rFpwq9uSJePySaxkXXJhJda7BQWR9CxEFAdppjiP2", 1, new DateTime(2025, 8, 13, 18, 48, 42, 517, DateTimeKind.Utc).AddTicks(4000), new Guid("aef548ab-7c0b-46d5-948f-dadb55774be6") });

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_Ohs_EmployeeId",
                table: "Assignees",
                column: "Ohs_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Ohs_Employees_Ohs_EmployeeId",
                table: "Assignees",
                column: "Ohs_EmployeeId",
                principalTable: "Ohs_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
