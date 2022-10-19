using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRelationCategoryAndBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category_Id",
                table: "Book",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_Category_Id",
                table: "Book",
                column: "Category_Id",
                principalTable: "Category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_Category_Id",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_Category_Id",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Book");
        }
    }
}
