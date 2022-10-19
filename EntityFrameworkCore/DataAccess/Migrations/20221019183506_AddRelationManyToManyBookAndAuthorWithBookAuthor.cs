using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRelationManyToManyBookAndAuthorWithBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Book_Id1 = table.Column<int>(type: "int", nullable: false),
                    Author_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author_Author_Id1",
                        column: x => x.Author_Id1,
                        principalTable: "Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book_Book_Id1",
                        column: x => x.Book_Id1,
                        principalTable: "Book",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_Author_Id1",
                table: "BookAuthor",
                column: "Author_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_Book_Id1",
                table: "BookAuthor",
                column: "Book_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");
        }
    }
}
