using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class AssigneesTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("13b1aed6-74e1-4082-a686-9fcce635e727"));

            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("9de484a5-54c0-4751-98d2-7ff682625d00"), new DateTime(2025, 8, 13, 13, 43, 15, 763, DateTimeKind.Utc).AddTicks(3030), "admin@isg.com", "Sistem Admini", "$2a$11$V5iBwhiAzQa7G0grcevOwefk0Zye3dY3stuOdKEvITQWsyafTx3KS", 1, new DateTime(2025, 8, 13, 13, 43, 15, 763, DateTimeKind.Utc).AddTicks(3030), new Guid("2c304005-8ecb-4f49-8059-d646914c6175") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("9de484a5-54c0-4751-98d2-7ff682625d00"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("13b1aed6-74e1-4082-a686-9fcce635e727"), new DateTime(2025, 8, 13, 8, 1, 20, 84, DateTimeKind.Utc).AddTicks(1920), "admin@isg.com", "Sistem Admini", "$2a$11$y/.WRvGhGZB9OklYqwNtkeM9Z7vu0PHtbinuigbAC5j7S5/RobMGG", 1, new DateTime(2025, 8, 13, 8, 1, 20, 84, DateTimeKind.Utc).AddTicks(1930), new Guid("06e52067-7bd6-453a-885f-519ed15ca66b") });
        }
    }
}
