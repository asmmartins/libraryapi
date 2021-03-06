﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Repository.Migrations
{

    public partial class CreateViewBooksAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[BooksAuthors] AS SELECT A.Id AS AuthorId, A.Name AS AuthorName, COUNT(BA.BookId) AS Books FROM [dbo].[BookAuthor] AS BA INNER JOIN [dbo].[Books] AS B ON B.Id = BA.BookId INNER JOIN [dbo].[Authors] AS A ON A.Id = BA.AuthorId GROUP BY A.Id, A.Name;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [dbo].[BooksAuthors];");
        }
    }
}
