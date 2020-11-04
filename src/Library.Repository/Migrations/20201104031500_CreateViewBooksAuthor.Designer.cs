using Library.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Repository.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20201104031500_CreateViewBooksAuthor")]
    partial class CreateViewBooksAuthor
    {
    }
}
