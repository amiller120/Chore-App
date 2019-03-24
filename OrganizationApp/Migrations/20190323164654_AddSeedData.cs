using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationApp.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "choreItems",
                columns: new[] { "Id", "AssignedTo", "CreatedDate", "IsComplete", "Name" },
                values: new object[] { 1, "Adam", new DateTime(2019, 3, 23, 12, 46, 54, 556, DateTimeKind.Local).AddTicks(6060), false, "Dishes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "choreItems",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
