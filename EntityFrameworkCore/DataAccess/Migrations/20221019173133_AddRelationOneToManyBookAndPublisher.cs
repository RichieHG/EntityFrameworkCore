using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRelationOneToManyBookAndPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Publisher_Id",
                table: "Book",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_Publisher_Id",
                table: "Book",
                column: "Publisher_Id",
                principalTable: "Publisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_Publisher_Id",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_Publisher_Id",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Book");
        }
    }
}
