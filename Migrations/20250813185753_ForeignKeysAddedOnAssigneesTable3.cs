using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAddedOnAssigneesTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("26b51a77-94c5-4d0c-945a-0245cf7cafdd"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("14c3777b-8f1b-499f-84db-23f584a6cf11"), new DateTime(2025, 8, 13, 18, 57, 53, 296, DateTimeKind.Utc).AddTicks(1750), "admin@isg.com", "Sistem Admini", "$2a$11$5jViKApjeFd7cU7a3veeTuKwzdERIrur/.imEk.8X0Iyq2JB1Zvcm", 1, new DateTime(2025, 8, 13, 18, 57, 53, 296, DateTimeKind.Utc).AddTicks(1750), new Guid("bf08c4fa-13bb-4afa-bf2b-4378ab12cc03") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("14c3777b-8f1b-499f-84db-23f584a6cf11"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("26b51a77-94c5-4d0c-945a-0245cf7cafdd"), new DateTime(2025, 8, 13, 18, 52, 34, 125, DateTimeKind.Utc).AddTicks(8350), "admin@isg.com", "Sistem Admini", "$2a$11$.rqU0bxtqMQfHAf1cL8cfOp7klX4U6v99aBVRkzm35Ta9F4OzZSvq", 1, new DateTime(2025, 8, 13, 18, 52, 34, 125, DateTimeKind.Utc).AddTicks(8350), new Guid("7a1c8dd7-c4e4-4796-81e2-bf017076f9dd") });
        }
    }
}
