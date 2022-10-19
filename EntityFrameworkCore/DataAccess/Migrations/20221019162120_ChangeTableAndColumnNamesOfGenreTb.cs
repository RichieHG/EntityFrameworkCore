using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeTableAndColumnNamesOfGenreTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "tb_Genre");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tb_Genre",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Genre",
                table: "tb_Genre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Genre",
                table: "tb_Genre");

            migrationBuilder.RenameTable(
                name: "tb_Genre",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genre",
                newName: "GenreName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");
        }
    }
}
