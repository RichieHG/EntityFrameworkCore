﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddStoredProcedureAndView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetOnlyBookDetails
                AS
                SELECT  m.ISBN,m.Title,m.Price FROM dbo.Fluent_Book m
            ");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.getAllBookDetails   
                    @bookId int
                AS   
                    SET NOCOUNT ON;  
                    SELECT  *  FROM dbo.Fluent_Book b
	                WHERE b.Book_Id=@bookId
                GO  
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.GetOnlyBookDetails");

            migrationBuilder.Sql("DROP PROCEDURE dbo.getAllBookDetails");
        }
    }
}
