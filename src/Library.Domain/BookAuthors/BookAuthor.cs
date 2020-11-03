using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Shared;
using System;

namespace Library.Domain.BookAuthors
{
    public partial class BookAuthor : IAggregateRoot
    {
        public Guid BookId { get; private set; }
        public Book Book { get; private set; }

        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; }

        protected BookAuthor() { }
    }
}