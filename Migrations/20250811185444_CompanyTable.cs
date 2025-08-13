using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class CompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("419e4b74-1f03-43ed-ad30-0d0ed1d3b30b"));

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyAddress = table.Column<string>(type: "text", nullable: false),
                    CompanyPhone = table.Column<string>(type: "text", nullable: false),
                    CompanyEmail = table.Column<string>(type: "text", nullable: false),
                    CompanyTaxNumber = table.Column<string>(type: "text", nullable: false),
                    WarningClass = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("ac7edb29-98ab-44ec-93b7-3bba044059e2"), new DateTime(2025, 8, 11, 18, 54, 44, 317, DateTimeKind.Utc).AddTicks(1970), "admin@isg.com", "Sistem Admini", "$2a$11$yIqSK6cS8XNPBmrM1oJyZeYfWnPCSL/JQlNV1f4u6U9lPEcIXUJBS", 1, new DateTime(2025, 8, 11, 18, 54, 44, 317, DateTimeKind.Utc).AddTicks(1970), new Guid("5fc25ed2-f746-4735-adfe-6e05f6c7a131") });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyEmail",
                table: "Company",
                column: "CompanyEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_ManagerId",
                table: "Company",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("ac7edb29-98ab-44ec-93b7-3bba044059e2"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("419e4b74-1f03-43ed-ad30-0d0ed1d3b30b"), new DateTime(2025, 8, 10, 15, 23, 50, 736, DateTimeKind.Utc).AddTicks(2760), "admin@isg.com", "Sistem Admini", "$2a$11$BBC2KPUDOPeU8DlvgupKKuG7aBUCI/VltWbMVZ7x7LHm2.QpLuh9e", 1, new DateTime(2025, 8, 10, 15, 23, 50, 736, DateTimeKind.Utc).AddTicks(2760), new Guid("c38fe6cf-1e2e-4e7f-8d0f-2188513972d8") });
        }
    }
}
