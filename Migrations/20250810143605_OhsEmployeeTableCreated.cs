using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class OhsEmployeeTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("43d0563d-96de-42a4-a79f-1bebaa967c40"));

            migrationBuilder.CreateTable(
                name: "Ohs_Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IdentityNumber = table.Column<int>(type: "integer", nullable: false),
                    Mission = table.Column<string>(type: "text", nullable: false),
                    CertificateNumber = table.Column<int>(type: "integer", nullable: false),
                    CertificateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ohs_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ohs_Employees_Email",
                table: "Ohs_Employees",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ohs_Employees");

            migrationBuilder.DropIndex(
                name: "IX_Managers_Email",
                table: "Managers");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("43d0563d-96de-42a4-a79f-1bebaa967c40"), new DateTime(2025, 8, 10, 14, 10, 7, 627, DateTimeKind.Utc).AddTicks(4710), "admin@isg.com", "Sistem Admini", "$2a$11$nTEFBE2nLvTa43vwJ6jnZ.OPzcmSR7Df/WgJd83GpaCW3qKDlWatC", 1, new DateTime(2025, 8, 10, 14, 10, 7, 627, DateTimeKind.Utc).AddTicks(4710), new Guid("6e776394-1af5-4c4d-b373-3f7d8f2bc34d") });
        }
    }
}
