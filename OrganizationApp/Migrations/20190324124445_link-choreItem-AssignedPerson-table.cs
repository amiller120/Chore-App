using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OrganizationApp.Migrations
{
    public partial class linkchoreItemAssignedPersontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "choreItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "choreItems");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "choreItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssignedPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedPerson", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_choreItems_AssignedToId",
                table: "choreItems",
                column: "AssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems",
                column: "AssignedToId",
                principalTable: "AssignedPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems");

            migrationBuilder.DropTable(
                name: "AssignedPerson");

            migrationBuilder.DropIndex(
                name: "IX_choreItems_AssignedToId",
                table: "choreItems");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "choreItems");

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "choreItems",
                nullable: true);

            migrationBuilder.InsertData(
                table: "choreItems",
                columns: new[] { "Id", "AssignedTo", "CreatedDate", "IsComplete", "Name" },
                values: new object[] { 1, "Adam", new DateTime(2019, 3, 23, 12, 46, 54, 556, DateTimeKind.Local).AddTicks(6060), false, "Dishes" });
        }
    }
}
