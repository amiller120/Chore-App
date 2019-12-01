using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationApp.Migrations
{
    public partial class UpdateTableCasing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_choreItems",
                table: "choreItems");

            migrationBuilder.RenameTable(
                name: "choreItems",
                newName: "ChoreItems");

            migrationBuilder.RenameIndex(
                name: "IX_choreItems_AssignedToId",
                table: "ChoreItems",
                newName: "IX_ChoreItems_AssignedToId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreItems",
                table: "ChoreItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreItems_AssignedPerson_AssignedToId",
                table: "ChoreItems",
                column: "AssignedToId",
                principalTable: "AssignedPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoreItems_AssignedPerson_AssignedToId",
                table: "ChoreItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreItems",
                table: "ChoreItems");

            migrationBuilder.RenameTable(
                name: "ChoreItems",
                newName: "choreItems");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreItems_AssignedToId",
                table: "choreItems",
                newName: "IX_choreItems_AssignedToId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_choreItems",
                table: "choreItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_choreItems_AssignedPerson_AssignedToId",
                table: "choreItems",
                column: "AssignedToId",
                principalTable: "AssignedPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
