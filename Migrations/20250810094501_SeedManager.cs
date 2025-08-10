using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class SeedManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("38cc51b3-41fc-4d4c-a791-6cc2c98e921a"), new DateTime(2025, 8, 10, 9, 45, 1, 613, DateTimeKind.Utc).AddTicks(8960), "admin@isg.com", "Sistem Yöneticisi", "$2a$11$PaJJon0daMjcZesLVEodUuLEVsqswecGZ/8laCjBFwvfaHQdpaX2G", 2, new DateTime(2025, 8, 10, 9, 45, 1, 613, DateTimeKind.Utc).AddTicks(8960), new Guid("1d737574-09fb-4d55-8f1b-3ac7c68fe0dd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
