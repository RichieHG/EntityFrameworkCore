using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddOneToOneBookAndBookDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_Category_Id",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Book_Category_Id",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Book",
                newName: "BookDetails_Id");

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    BookDetails_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.BookDetails_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookDetails_Id",
                table: "Book",
                column: "BookDetails_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookDetails_BookDetails_Id",
                table: "Book",
                column: "BookDetails_Id",
                principalTable: "BookDetails",
                principalColumn: "BookDetails_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookDetails_BookDetails_Id",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookDetails_Id",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "BookDetails_Id",
                table: "Book",
                newName: "Category_Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_Id);
                });

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
    }
}
