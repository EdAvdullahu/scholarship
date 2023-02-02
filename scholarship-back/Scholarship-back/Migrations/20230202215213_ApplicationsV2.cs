using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholarship_back.Migrations
{
    public partial class ApplicationsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentLists_documentListId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "documentListId",
                table: "Documents",
                newName: "DocumentListId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_documentListId",
                table: "Documents",
                newName: "IX_Documents_DocumentListId");

            migrationBuilder.RenameColumn(
                name: "documentListId",
                table: "DocumentLists",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentLists_DocumentListId",
                table: "Documents",
                column: "DocumentListId",
                principalTable: "DocumentLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentLists_DocumentListId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "DocumentListId",
                table: "Documents",
                newName: "documentListId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_DocumentListId",
                table: "Documents",
                newName: "IX_Documents_documentListId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DocumentLists",
                newName: "documentListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentLists_documentListId",
                table: "Documents",
                column: "documentListId",
                principalTable: "DocumentLists",
                principalColumn: "documentListId");
        }
    }
}
