using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddNullableBookDetailsIdInBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_BookDetails_BookDetails_Id",
                table: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_BookDetails_Id",
                table: "Fluent_Book");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetails_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_BookDetails_Id",
                table: "Fluent_Book",
                column: "BookDetails_Id",
                unique: true,
                filter: "[BookDetails_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_BookDetails_BookDetails_Id",
                table: "Fluent_Book",
                column: "BookDetails_Id",
                principalTable: "Fluent_BookDetails",
                principalColumn: "BookDetails_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_BookDetails_BookDetails_Id",
                table: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_BookDetails_Id",
                table: "Fluent_Book");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetails_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_BookDetails_Id",
                table: "Fluent_Book",
                column: "BookDetails_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_BookDetails_BookDetails_Id",
                table: "Fluent_Book",
                column: "BookDetails_Id",
                principalTable: "Fluent_BookDetails",
                principalColumn: "BookDetails_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
