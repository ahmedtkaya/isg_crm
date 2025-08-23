using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class MissionTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("c11c1fa2-39b6-472d-96df-9b84c1b32dce"));

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssigneesId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToGoDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Assignees_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Assignees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AssigneesId",
                table: "Missions",
                column: "AssigneesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("c11c1fa2-39b6-472d-96df-9b84c1b32dce"), new DateTime(2025, 8, 16, 17, 32, 49, 383, DateTimeKind.Utc).AddTicks(6880), "admin@isg.com", "Sistem Admini", "$2a$11$8v8peXZGISUtawuRhDIrce14nSAMHUyPChkMCLtnRlhnYa7vgFjva", 1, new DateTime(2025, 8, 16, 17, 32, 49, 383, DateTimeKind.Utc).AddTicks(6880), new Guid("f3cb3c6e-8b32-458e-94be-9c6a70870bb6") });
        }
    }
}
