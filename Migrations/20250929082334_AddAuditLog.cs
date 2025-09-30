using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Assignees_AssigneesId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_AssigneesId",
                table: "Missions");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("c0913138-0395-42a3-9012-2f38d54e71f9"));

            migrationBuilder.DropColumn(
                name: "AssigneesId",
                table: "Missions");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AssignId",
                table: "Missions",
                column: "AssignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Assignees_AssignId",
                table: "Missions",
                column: "AssignId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Assignees_AssignId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_AssignId",
                table: "Missions");

            migrationBuilder.AddColumn<Guid>(
                name: "AssigneesId",
                table: "Missions",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("c0913138-0395-42a3-9012-2f38d54e71f9"), new DateTime(2025, 8, 21, 9, 6, 4, 806, DateTimeKind.Utc).AddTicks(4940), "admin@isg.com", "Sistem Admini", "$2a$11$xqhgHgpjN93z3mfGxLnglOSvbNMw68SHDcEbExePuYS06NM.YB32u", 1, new DateTime(2025, 8, 21, 9, 6, 4, 806, DateTimeKind.Utc).AddTicks(4970), new Guid("d26794af-377d-484b-9e33-1c763b385f54") });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AssigneesId",
                table: "Missions",
                column: "AssigneesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Assignees_AssigneesId",
                table: "Missions",
                column: "AssigneesId",
                principalTable: "Assignees",
                principalColumn: "Id");
        }
    }
}
