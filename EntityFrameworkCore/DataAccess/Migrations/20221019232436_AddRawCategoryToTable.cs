using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRawCategoryToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES('Cat 1')");
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES('Cat 2')");
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES('Cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
