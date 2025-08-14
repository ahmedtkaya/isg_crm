using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isg_crm.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAddedOnAssigneesTableAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("5a59cd2f-014d-46fb-a669-8a3471ea4b07"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("d2203d3e-4301-41c3-b383-4233f8cd0ffb"), new DateTime(2025, 8, 13, 18, 48, 42, 517, DateTimeKind.Utc).AddTicks(4000), "admin@isg.com", "Sistem Admini", "$2a$11$A/R8XaQ7IWk/rFpwq9uSJePySaxkXXJhJda7BQWR9CxEFAdppjiP2", 1, new DateTime(2025, 8, 13, 18, 48, 42, 517, DateTimeKind.Utc).AddTicks(4000), new Guid("aef548ab-7c0b-46d5-948f-dadb55774be6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("d2203d3e-4301-41c3-b383-4233f8cd0ffb"));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Type", "UpdatedAt", "Uuid" },
                values: new object[] { new Guid("5a59cd2f-014d-46fb-a669-8a3471ea4b07"), new DateTime(2025, 8, 13, 18, 41, 53, 159, DateTimeKind.Utc).AddTicks(4840), "admin@isg.com", "Sistem Admini", "$2a$11$eJVivn9OoZlaj/.3bM6BO.SB/bs6iJGkR9RbSDz6fGXrQgfKogxLq", 1, new DateTime(2025, 8, 13, 18, 41, 53, 159, DateTimeKind.Utc).AddTicks(4840), new Guid("5cd89e23-b504-4daf-a677-13bb24a7f729") });
        }
    }
}
