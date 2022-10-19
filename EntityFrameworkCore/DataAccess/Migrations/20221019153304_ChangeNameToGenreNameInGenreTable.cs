using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeNameToGenreNameInGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genre",
                newName: "GenreName");

            //migrationBuilder.Sql("YUPDATE dbo.Genre SET GenreName = Name"); //This will copy all values in Name colummn to GenreName column
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genre",
                newName: "Name");

            //migrationBuilder.Sql("YUPDATE dbo.Genre SET Name = GenreName"); //This will copy all values in GenreName colummn to Name column in a reverse movement

        }
    }
}
