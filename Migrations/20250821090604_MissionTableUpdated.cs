using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class MissionTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "EmployeeIdId",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "Missions",
                newName: "EmployeeId");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("c0913138-0395-42a3-9012-2f38d54e71f9"), new DateTime(2025, 8, 21, 9, 6, 4, 806, DateTimeKind.Utc).AddTicks(4940), "admin@isg.com", "Sistem Admini", "$2a$11$xqhgHgpjN93z3mfGxLnglOSvbNMw68SHDcEbExePuYS06NM.YB32u", 1, new DateTime(2025, 8, 21, 9, 6, 4, 806, DateTimeKind.Utc).AddTicks(4970), new Guid("d26794af-377d-484b-9e33-1c763b385f54") });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_EmployeeId",
                table: "Missions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Ohs_Employees_EmployeeId",
                table: "Missions",
                column: "EmployeeId",
                principalTable: "Ohs_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Ohs_Employees_EmployeeId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_EmployeeId",
                table: "Missions");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("c0913138-0395-42a3-9012-2f38d54e71f9"));

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Missions",
                newName: "Employee");

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
    }
}
