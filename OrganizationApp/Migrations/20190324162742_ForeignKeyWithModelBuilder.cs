using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationApp.Migrations
{
    public partial class ForeignKeyWithModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems");

            migrationBuilder.AddForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems",
                column: "AssignedToId",
                principalTable: "AssignedPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems");

            migrationBuilder.AddForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems",
                column: "AssignedToId",
                principalTable: "AssignedPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
