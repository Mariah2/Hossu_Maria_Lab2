using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hossu_Maria_Lab2.Migrations
{
    public partial class Author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Book",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorID");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "ID");
        }
    }
}
